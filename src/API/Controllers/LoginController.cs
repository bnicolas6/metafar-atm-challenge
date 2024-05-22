using MediatR;
using Metafar.ATM.Challenge.API.ViewModels;
using Metafar.ATM.Challenge.Application.UseCase.Login;
using Metafar.ATM.Challenge.Application.UseCase.Login.Response;
using Metafar.ATM.Challenge.Common.Http;
using Metafar.ATM.Challenge.Common.Http.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Metafar.ATM.Challenge.API.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ATMController
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Devuelve un token JWT
        /// </summary>
        /// <param name="login">La informacion necesaria para la autenticacion</param>
        /// <returns>Un token JWT</returns>
        [HttpPost("/api/login")]
        [ProducesResponseType(typeof(LoginCmdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ATMError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<ATMError>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(List<ATMError>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(List<ATMError>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel login)
        {
            var request = new LoginCmd(login.NumeroDeTarjeta, login.Pin);
            var response = await _mediator.Send(request);

            return ProcessResult(response);
        }
    }
}
