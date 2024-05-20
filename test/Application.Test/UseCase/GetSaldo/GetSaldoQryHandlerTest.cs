using FluentAssertions;
using Metafar.ATM.Challenge.Application.UseCase.GetSaldo;
using Metafar.ATM.Challenge.Domain.Enums;
using Metafar.ATM.Challenge.Domain.Interfaces.Queries;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;

namespace Application.Test.UseCase.GetSaldo
{
    public class GetSaldoQryHandlerTest
    {
        private readonly Mock<ICuentasQuery> _cuentaQuery;
        private readonly Mock<ILogger<GetSaldoQryHandler>> _logger;

        private GetSaldoQry _qry;
        private readonly GetSaldoQryHandler _qryHandler;

        private const string NUMERO_DE_TARJETA = "1122334455667788";
        
        public GetSaldoQryHandlerTest()
        {
            _cuentaQuery = new Mock<ICuentasQuery>();
            _logger = new Mock<ILogger<GetSaldoQryHandler>>();

            _qryHandler = new GetSaldoQryHandler(
                _cuentaQuery.Object, 
                _logger.Object);
        }

        [Fact]
        public async Task Handle_DataBaseQueryExecuted_ReturnOk()
        {
            //Arrange
            _qry = new(NUMERO_DE_TARJETA);

            //Act
            var response = await _qryHandler.Handle(_qry, CancellationToken.None);

            //Assert
            _cuentaQuery.Verify(x => x.GetSaldoAsync(
                NUMERO_DE_TARJETA, 
                ETipoOperacion.Extraccion), 
                Times.Once);
        }

        [Fact]
        public async Task Handle_ExceptionThrown_ReturnInternalServerError()
        {
            //Arrange
            _qry = new(NUMERO_DE_TARJETA);
            _cuentaQuery.Setup(x => x.GetSaldoAsync(
                It.IsAny<string>(), 
                It.IsAny<ETipoOperacion>()))
                .ThrowsAsync(new Exception());

            //Act
            var response = await _qryHandler.Handle(_qry, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }
    }
}
