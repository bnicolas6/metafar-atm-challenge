using MediatR;
using Metafar.ATM.Challenge.API.ViewModels;
using Metafar.ATM.Challenge.Application.UseCase.Login;
using Metafar.ATM.Challenge.Common.Http;
using Metafar.ATM.Challenge.Common.Http.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Metafar.ATM.Challenge.API.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LoginController : ApiController
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtener Token de Authenticacion
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("/api/login")]
        [ProducesResponseType(typeof(LoginCmdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<ApiError>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(List<ApiError>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(List<ApiError>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromBody] LoginViewModel login)
        {
            var request = new LoginCmd(login.NumeroDeTarjeta, login.Pin);
            var response = await _mediator.Send(request);

            return ProcessResult(response);
        }
    }
}
