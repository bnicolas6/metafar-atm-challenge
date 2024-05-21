using MediatR;
using Metafar.ATM.Challenge.Application.UseCase.GetSaldo.Response;
using Metafar.ATM.Challenge.Common.Http.Response;
using Metafar.ATM.Challenge.Domain.Enums;
using Metafar.ATM.Challenge.Domain.Interfaces.Queries;
using Metafar.ATM.Challenge.Domain.QryResults;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Metafar.ATM.Challenge.Application.UseCase.GetSaldo
{
    public class GetSaldoQryHandler : IRequestHandler<GetSaldoQry, ATMResponse<GetSaldoQryResponse>>
    {
        private readonly ICuentasQuery _cuentaQuery;
        private readonly ILogger<GetSaldoQryHandler> _logger;

        public GetSaldoQryHandler(
            ICuentasQuery cuentaQuery, 
            ILogger<GetSaldoQryHandler> logger)
        {
            _cuentaQuery = cuentaQuery;
            _logger = logger;
        }

        public async Task<ATMResponse<GetSaldoQryResponse>> Handle(
            GetSaldoQry request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var qryResult = await GetSaldoCuentaAsync(request.NumeroDeTarjeta);
                return GetSaldoResponse(qryResult);
            }
            catch(Exception ex)
            {
                return GetExceptionResponse(ex.Message);
            }

        }

        private async Task<GetCuentaSaldoQryResult> GetSaldoCuentaAsync(string numeroDeTarjeta)
        {
            return await _cuentaQuery.GetSaldoAsync(
                numeroDeTarjeta,
                ETipoOperacion.Extraccion);
        } 

        private ATMResponse<GetSaldoQryResponse> GetSaldoResponse(GetCuentaSaldoQryResult response)
        {
            return new ATMResponse<GetSaldoQryResponse>
            {
                HttpStatusCode = HttpStatusCode.OK,
                Content = (GetSaldoQryResponse)response
            };
        }

        private ATMResponse<GetSaldoQryResponse> GetExceptionResponse(string errorMessage)
        {
            return new ATMResponse<GetSaldoQryResponse>
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
