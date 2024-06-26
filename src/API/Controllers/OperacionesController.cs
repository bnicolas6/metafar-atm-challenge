﻿using MediatR;
using Metafar.ATM.Challenge.Application.UseCase.GetOperaciones;
using Metafar.ATM.Challenge.Application.UseCase.GetOperaciones.Response;
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
    public class OperacionesController : ATMController
    {
        private readonly IMediator _mediator;

        public OperacionesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene las operaciones de una cuenta vinculada a una tarjeta autenticada
        /// </summary>
        /// <param name="pageNumber">El numero de pagina que se desea consultar</param>
        /// <returns>Las operaciones de la cuenta</returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetOperacionesQryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ATMError>), StatusCodes.Status400BadRequest)]
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
