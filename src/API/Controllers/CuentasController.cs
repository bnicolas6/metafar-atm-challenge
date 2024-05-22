using MediatR;
using Metafar.ATM.Challenge.API.ViewModels;
using Metafar.ATM.Challenge.Application.UseCase.ExtractSaldo;
using Metafar.ATM.Challenge.Application.UseCase.GetSaldo;
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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CuentasController : ATMController
    {
        private readonly IMediator _mediator;

        public CuentasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene el saldo de una cuenta vinculada a una tarjeta autenticada
        /// </summary>
        /// <returns>El saldo de la cuenta</returns>
        [HttpGet("saldo")]
        [ProducesResponseType(typeof(GetSaldoQryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ATMError>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSaldoAsync()
        {
            var numeroDeTarjeta = User.GetNumeroDeTarjetaClaim();

            var request = new GetSaldoQry(numeroDeTarjeta);
            var response = await _mediator.Send(request);

            return ProcessResult(response);
        }

        /// <summary>
        /// Extraer saldo de una cuenta vinculada a una tarjeta autenticada
        /// </summary>
        /// <param name="extract">El monto a extraer de la cuenta</param>
        /// <returns>El resultado de la operacion de extraccion</returns>
        [HttpPost("extraer-saldo")]
        [ProducesResponseType(typeof(GetSaldoQryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ATMError>), StatusCodes.Status502BadGateway)]
        [ProducesResponseType(typeof(List<ATMError>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ExtractSaldoAsync([FromBody] ExtractViewModel extract)
        {
            var numeroDeTarjeta = User.GetNumeroDeTarjetaClaim();

            var request = new ExtractSaldoCmd(numeroDeTarjeta, extract.Monto);
            var response = await _mediator.Send(request);

            return ProcessResult(response);
        }
    }
}
