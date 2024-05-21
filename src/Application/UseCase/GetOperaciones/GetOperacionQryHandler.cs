using MediatR;
using Metafar.ATM.Challenge.Application.UseCase.GetOperaciones.Response;
using Metafar.ATM.Challenge.Common.ErrorMessages;
using Metafar.ATM.Challenge.Common.Http.Response;
using Metafar.ATM.Challenge.Domain.Interfaces.Queries;
using Metafar.ATM.Challenge.Domain.QryResults;
using Metafar.ATM.Challenge.Domain.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;

namespace Metafar.ATM.Challenge.Application.UseCase.GetOperaciones
{
    public class GetOperacionQryHandler : IRequestHandler<GetOperacionQry, ATMResponse<GetOperacionesQryResponse>>
    {
        private readonly IOperacionesQuery _operacionesQuery;
        private readonly ILogger<GetOperacionQryHandler> _logger;

        private readonly PaginationSettings _paginationSettings;

        public GetOperacionQryHandler(
            IOperacionesQuery operacionesQuery,
            IOptions<PaginationSettings> options,
            ILogger<GetOperacionQryHandler> logger)
        {
            _operacionesQuery = operacionesQuery;
            _logger = logger;

            _paginationSettings = options.Value;
        }

        public async Task<ATMResponse<GetOperacionesQryResponse>> Handle(
            GetOperacionQry request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var pageNumber = GetPageNumber(request.PageNumber);

                var (operacionesResult, totalRows) = await _operacionesQuery.GetOperacionesAsync(
                    request.NumeroDeTarjeta, 
                    _paginationSettings.PageSize, 
                    pageNumber);

                var operacionesQryResponse = GetMappedOperaciones(operacionesResult);

                return GetOperacionesResponse(
                    operacionesQryResponse, 
                    _paginationSettings.PageSize, 
                    pageNumber, 
                    totalRows);

            }
            catch (OverflowException)
            {
                return GetExceptionResponse(OperacionErroMessage.PAGENUMBER_OVERFLOW);
            }
            catch (Exception ex)
            {
                return GetExceptionResponse(ex.Message);
            }
        }

        private int GetPageNumber(int? pageNumber)
        {
            return pageNumber.HasValue ? 
                pageNumber.Value : 
                _paginationSettings.DefaultPageNumber;
        }

        private List<GetOperacionQryResponse> GetMappedOperaciones(IEnumerable<GetOperacionQryResult> operacionesResult)
        {
            var operacionesQryResponse = new List<GetOperacionQryResponse>();

            if (!operacionesResult.Any())
                return operacionesQryResponse;

            foreach (var operacion in operacionesResult)
                operacionesQryResponse.Add((GetOperacionQryResponse)operacion);

            return operacionesQryResponse;
        }

        private ATMResponse<GetOperacionesQryResponse> GetOperacionesResponse(
            List<GetOperacionQryResponse> operaciones, 
            int pageSize, 
            int pageNumber, 
            int totalRows)
        {
            return new ATMResponse<GetOperacionesQryResponse>
            {
                HttpStatusCode = HttpStatusCode.OK,
                Content = new GetOperacionesQryResponse(
                    operaciones,
                    pageSize,
                    pageNumber,
                    totalRows)
            };
        }

        private ATMResponse<GetOperacionesQryResponse> GetExceptionResponse(string errorMessage)
        {
            return new ATMResponse<GetOperacionesQryResponse>
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
