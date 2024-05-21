using MediatR;
using Metafar.ATM.Challenge.Application.UseCase.GetOperaciones;
using Metafar.ATM.Challenge.Application.UseCase.GetSaldo.Response;
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
    public class OperacionController : ATMController
    {
        private readonly IMediator _mediator;

        public OperacionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Consultar operaciones
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpGet("/operaciones")]
        [ProducesResponseType(typeof(GetSaldoQryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetSaldoQryResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<ATMError>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOperacionesAsync(int? pageNumber)
        {
            var numeroDeTarjeta = User.GetNumeroDeTarjetaClaim();

            var request = new GetOperacionQry(numeroDeTarjeta, pageNumber);
            var response = await _mediator.Send(request);

            return ProcessResult(response);
        }
    }
}
