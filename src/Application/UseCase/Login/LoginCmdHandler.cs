using MediatR;
using Metafar.ATM.Challenge.Common.ErrorMessages;
using Metafar.ATM.Challenge.Common.Http.Response;
using Metafar.ATM.Challenge.Domain.Entities;
using Metafar.ATM.Challenge.Domain.Enums;
using Metafar.ATM.Challenge.Domain.Interfaces;
using Metafar.ATM.Challenge.Domain.Interfaces.Commands;
using Metafar.ATM.Challenge.Domain.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;

namespace Metafar.ATM.Challenge.Application.UseCase.Login
{
    public class LoginCmdHandler : IRequestHandler<LoginCmd, ATMResponse<LoginCmdResponse>>
    {
        private readonly IMemoryCacheRepository _memoryCacheRepository;
        private readonly IRepository<Cuenta> _repository;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly ILogger<LoginCmdHandler> _logger;

        private readonly LoginSettings _loginSettings;

        public LoginCmdHandler(
            IMemoryCacheRepository memoryCacheRepository,
            IRepository<Cuenta> repository,
            ITokenGenerator tokenGenerator, 
            IOptions<LoginSettings> options,
            ILogger<LoginCmdHandler> logger)
        {
            _memoryCacheRepository = memoryCacheRepository;
            _repository = repository;
            _tokenGenerator = tokenGenerator;
            _loginSettings = options.Value;
            _logger = logger;
        }

        public async Task<ATMResponse<LoginCmdResponse>> Handle(
            LoginCmd request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var cuenta = await FindCuentaAsync(request.NumeroDeTarjeta);

                if (cuenta == null)
                    return CuentaNotFound();

                if (IsBlockedCuenta(cuenta))
                    return GetTarjetaBlockedResponse(CuentaErrorMessage.TARJETA_WAS_BLOCKED);

                if (!IsValidPin(cuenta, request.Pin))
                    return await GetFailedAttemptsResponse(
                        cuenta, 
                        request.NumeroDeTarjeta);

                ResetFailedAttempts(request.NumeroDeTarjeta);

                return GetTokenResponse(request.NumeroDeTarjeta);
            }
            catch (Exception ex)
            {
                return GetExceptionResponse(ex.Message);
            }
        }

        private async Task<Cuenta> FindCuentaAsync(string numeroDeTarjeta)
        {
            return await _repository.FindByAsync(x => x.NumeroDeTarjeta == numeroDeTarjeta);
        }

        private ATMResponse<LoginCmdResponse> CuentaNotFound()
        {
            return new ATMResponse<LoginCmdResponse>
            {
                HttpStatusCode = HttpStatusCode.BadRequest,
                Errors = new List<ATMError>
                {
                    new ATMError
                    {
                        PropertyName = nameof(LoginCmd.NumeroDeTarjeta),
                        Message = CuentaErrorMessage.CUENTA_NOT_FOUND
                    }
                }
            };
        }

        private bool IsValidPin(Cuenta cuenta, string pin)
        {
            return string.Equals(cuenta.Pin, pin);
        }

        private bool IsBlockedCuenta(Cuenta cuenta)
        {
            return cuenta.EstadoTarjetaId == (byte)EEstadoTarjeta.Bloqueado;
        }

        private void ResetFailedAttempts(string numeroDeTarjeta)
        {
            _memoryCacheRepository.Delete(numeroDeTarjeta);
        }

        private ATMResponse<LoginCmdResponse> GetFailAttemptResponse()
        {
            return new ATMResponse<LoginCmdResponse>
            {
                HttpStatusCode = HttpStatusCode.Unauthorized,
                Errors = new List<ATMError>
                {
                    new ATMError
                    {
                        PropertyName = nameof(LoginCmd.Pin),
                        Message = CuentaErrorMessage.TARJETA_FAIL_ATTEMPT
                    }
                }
            };
        }

        private async Task<ATMResponse<LoginCmdResponse>> GetFailedAttemptsResponse(
            Cuenta cuenta, 
            string numeroDeTarjeta)
        {
            if (_memoryCacheRepository.TryGetItem(numeroDeTarjeta, out LoginAttempts loginAttempts))
            {
                AddNewFailedAttempt(loginAttempts);

                if (AreFailedAttemptsMaximumExceeded(loginAttempts))
                {
                    await BlockTarjeta(cuenta);
                    return GetTarjetaBlockedResponse(CuentaErrorMessage.TARJETA_IS_BLOCKED);
                }
                    
                UpdateAttemptFailed(loginAttempts, numeroDeTarjeta);
            }
            else
            {
                InitializeFirstAttemptFailed(numeroDeTarjeta);
            }

            return GetFailAttemptResponse();
        }

        private void AddNewFailedAttempt(LoginAttempts loginAttempts)
        {
            loginAttempts.Attempts++;
        }

        private bool AreFailedAttemptsMaximumExceeded(LoginAttempts loginAttempts)
        {
            return loginAttempts.Attempts == _loginSettings.NumberOfFailedAttemptsToBlock;
        }

        private async Task BlockTarjeta(Cuenta cuenta)
        {
            cuenta.EstadoTarjetaId = (byte)EEstadoTarjeta.Bloqueado;
            _repository.Update(cuenta);
            await _repository.SaveChangesAsync();
        }

        private void UpdateAttemptFailed(LoginAttempts loginAttempts, string numeroDeTarjeta)
        {
            _memoryCacheRepository.Update(numeroDeTarjeta, loginAttempts);
        }

        private void InitializeFirstAttemptFailed(string numeroDeTarjeta)
        {
            _memoryCacheRepository.Insert(
                numeroDeTarjeta, 
                new LoginAttempts 
                { 
                    NumeroDeTarjeta = numeroDeTarjeta 
                });
        }

        private ATMResponse<LoginCmdResponse> GetTarjetaBlockedResponse(string message)
        {
            return new ATMResponse<LoginCmdResponse>
            {
                HttpStatusCode = HttpStatusCode.Forbidden,
                Errors = new List<ATMError>
                {
                    new ATMError
                    {
                        PropertyName = nameof(LoginCmd.Pin),
                        Message = message
                    }
                }
            };
        }

        private ATMResponse<LoginCmdResponse> GetTokenResponse(string numeroDeTarjeta)
        {
            var parameters = new Dictionary<string, string>
            {
                { nameof(LoginCmd.NumeroDeTarjeta), numeroDeTarjeta }
            };

            var token = _tokenGenerator.GenerateToken(parameters);

            return new ATMResponse<LoginCmdResponse>
            {
                HttpStatusCode = HttpStatusCode.OK,
                Content = new LoginCmdResponse
                {
                    Token = token,
                }
            };
        }

        private ATMResponse<LoginCmdResponse> GetExceptionResponse(string errorMessage)
        {
            return new ATMResponse<LoginCmdResponse>
            {
                HttpStatusCode = HttpStatusCode.InternalServerError,
                Errors = new List<ATMError>
                {
                    new ATMError
                    {
                        Message = errorMessage
                    }
                }
            };
        }
    }
}
