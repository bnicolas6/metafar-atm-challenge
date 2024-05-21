using MediatR;
using Metafar.ATM.Challenge.Application.UseCase.ExtractSaldo.Response;
using Metafar.ATM.Challenge.Common.Http.Response;

namespace Metafar.ATM.Challenge.Application.UseCase.ExtractSaldo
{
    public class ExtractSaldoCmd : IRequest<ATMResponse<ExtractSaldoCmdResponse>>
    {
        public string NumeroDeTarjeta { get; set; }
        public decimal? Monto { get; set; }

        public ExtractSaldoCmd(string numeroDeTarjeta, decimal? monto)
        {
            NumeroDeTarjeta = numeroDeTarjeta;
            Monto = monto;
        }
    }
}
