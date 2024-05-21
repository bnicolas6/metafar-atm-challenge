using MediatR;
using Metafar.ATM.Challenge.Application.UseCase.GetOperaciones.Response;
using Metafar.ATM.Challenge.Common.Http.Response;

namespace Metafar.ATM.Challenge.Application.UseCase.GetOperaciones
{
    public class GetOperacionQry : IRequest<ATMResponse<GetOperacionesQryResponse>>
    {
        public string NumeroDeTarjeta { get; set; }
        public int? PageNumber { get; set; }

        public GetOperacionQry(string numeroDeTarjeta, int? pageNumber)
        {
            NumeroDeTarjeta = numeroDeTarjeta;
            PageNumber = pageNumber;
        }
    }
}
