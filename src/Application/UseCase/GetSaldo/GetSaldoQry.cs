using MediatR;
using Metafar.ATM.Challenge.Application.UseCase.GetSaldo.Response;
using Metafar.ATM.Challenge.Common.Http.Response;

namespace Metafar.ATM.Challenge.Application.UseCase.GetSaldo
{
    public class GetSaldoQry : IRequest<ATMResponse<GetSaldoQryResponse>>
    {
        public string NumeroDeTarjeta { get; set; }

        public GetSaldoQry(string numeroDeTarjeta)
        {
            NumeroDeTarjeta = numeroDeTarjeta;
        }
    }
}
