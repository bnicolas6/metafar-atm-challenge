using MediatR;
using Metafar.ATM.Challenge.Application.UseCase.GetSaldo;
using Metafar.ATM.Challenge.Application.UseCase.Login;
using Metafar.ATM.Challenge.Common.Http;
using Metafar.ATM.Challenge.Common.Http.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Metafar.ATM.Challenge.API.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    //[ApiVersion("1")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class CuentaController : ATMController
    {
        private readonly IMediator _mediator;

        public CuentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Consultar saldo de una cuenta
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpGet("saldo")]
        [ProducesResponseType(typeof(LoginCmdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ATMError>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSaldoAsync()
        {
            var numeroDeTarjeta = User.GetNumeroDeTarjetaClaim();

            var request = new GetSaldoQry(numeroDeTarjeta);
            var response = await _mediator.Send(request);

            return ProcessResult(response);
        }
    }
}
