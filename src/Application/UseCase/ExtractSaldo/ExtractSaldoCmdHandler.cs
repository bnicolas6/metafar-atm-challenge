using MediatR;
using Metafar.ATM.Challenge.Application.UseCase.ExtractSaldo.Response;
using Metafar.ATM.Challenge.Common.ErrorMessages;
using Metafar.ATM.Challenge.Common.Http.Response;
using Metafar.ATM.Challenge.Common.Utils;
using Metafar.ATM.Challenge.Domain.Entities;
using Metafar.ATM.Challenge.Domain.Enums;
using Metafar.ATM.Challenge.Domain.Interfaces.Commands;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Metafar.ATM.Challenge.Application.UseCase.ExtractSaldo
{
    public class ExtractSaldoCmdHandler : IRequestHandler<ExtractSaldoCmd, ATMResponse<ExtractSaldoCmdResponse>>
    {
        private readonly IRepository<Cuenta> _repository;
        private readonly ILogger<ExtractSaldoCmdHandler> _logger;

        public ExtractSaldoCmdHandler(
            IRepository<Cuenta> repository,
            ILogger<ExtractSaldoCmdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ATMResponse<ExtractSaldoCmdResponse>> Handle(
            ExtractSaldoCmd request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var monto = request.Monto.Value;
                var cuenta = await FindCuentaAsync(request.NumeroDeTarjeta);

                if (!IsValidMonto(cuenta, monto))
                    return GetInvalidMontoResponse(cuenta.Saldo);

                ExtractMontoFromCuenta(cuenta, monto);
                var operacion = AddOperacion(cuenta, monto);

                await _repository.SaveChangesAsync();

                return GetExtractMontoResponse(cuenta, operacion);

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

        private bool IsValidMonto(Cuenta cuenta, decimal monto)
        {
            return monto <= cuenta.Saldo;
        }

        private ATMResponse<ExtractSaldoCmdResponse> GetInvalidMontoResponse(decimal saldo)
        {
            return new ATMResponse<ExtractSaldoCmdResponse>
            {
                HttpStatusCode = HttpStatusCode.BadRequest,
                Errors = new List<ATMError>
                {
                    new ATMError
                    {
                        PropertyName = nameof(Cuenta.NumeroDeTarjeta),
                        Message = string.Format(CuentaErrorMessage.CUENTA_INVALID_EXTRACT, saldo.FormatDecimal())
                    }
                }
            };
        }

        private void ExtractMontoFromCuenta(Cuenta cuenta, decimal monto)
        {
            cuenta.Saldo -= monto;
        }

        private Operacion AddOperacion(Cuenta cuenta, decimal monto)
        {
            cuenta.OperacionesNavigation = new List<Operacion>();

            var operacion = new Operacion
            {
                CuentaId = cuenta.CuentaId,
                TipoOperacionId = (byte)ETipoOperacion.Extraccion,
                Fecha = DateTime.UtcNow,
                Monto = monto.GetRoundDecimal(),
                ActualizadoPor = cuenta.UsuarioId,
                ActualizadoEn = DateTime.UtcNow
            };

            cuenta.OperacionesNavigation.Add(operacion);

            return operacion;
        }

        private ATMResponse<ExtractSaldoCmdResponse> GetExtractMontoResponse(Cuenta cuenta, Operacion operacion)
        {
            var response = (ExtractSaldoCmdResponse)operacion;
            response.Cuenta = (CuentaCmdResponse)cuenta;

            return new ATMResponse<ExtractSaldoCmdResponse>
            {
                HttpStatusCode = HttpStatusCode.OK,
                Content = response
            };
        }

        private ATMResponse<ExtractSaldoCmdResponse> GetExceptionResponse(string errorMessage)
        {
            return new ATMResponse<ExtractSaldoCmdResponse>
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
