using MediatR;
using Metafar.ATM.Challenge.Common.Http.Response;
using System.Net;

namespace Metafar.ATM.Challenge.Application.UseCase.Login
{
    public class LoginCmd : IRequest<ApiResponse<LoginCmdResponse>>
    {
        public string NumeroDeTarjeta { get; set; }
        public string Pin { get; set; }

        public LoginCmd(string numeroDeTarjeta, string pin)
        {
            NumeroDeTarjeta = numeroDeTarjeta;
            Pin = pin;
        }
    }
}
