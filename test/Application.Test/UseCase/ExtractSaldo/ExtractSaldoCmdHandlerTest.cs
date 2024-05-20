using FluentAssertions;
using Metafar.ATM.Challenge.Application.UseCase.ExtractSaldo;
using Metafar.ATM.Challenge.Domain.Entities;
using Metafar.ATM.Challenge.Domain.Interfaces.Commands;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq.Expressions;
using System.Net;

namespace Application.Test.UseCase.ExtractSaldo
{
    public class ExtractSaldoCmdHandlerTest
    {
        private readonly Mock<IRepository<Cuenta>> _repository;
        private readonly Mock<ILogger<ExtractSaldoCmdHandler>> _logger;

        private readonly ExtractSaldoCmdHandler _cmdHandler;
        private readonly ExtractSaldoCmd _cmd;

        private const string VALID_NUMERO_DE_TARJETA = "1122334455667788";
        private const decimal VALID_MONTO = 100.75M;

        public ExtractSaldoCmdHandlerTest()
        {
            _repository = new Mock<IRepository<Cuenta>>();
            _logger = new Mock<ILogger<ExtractSaldoCmdHandler>>();

            _cmdHandler = new ExtractSaldoCmdHandler(
                _repository.Object, 
                _logger.Object);

            _cmd = new ExtractSaldoCmd(
                VALID_NUMERO_DE_TARJETA, 
                VALID_MONTO);
        }

        [Fact]
        public async Task Handle_MontoGreaterThanSaldoCuenta_ReturnBadRequestAndErrorMessage()
        {
            //Arrange
            var cuenta = new Cuenta
            {
                Saldo = VALID_MONTO - 1
            };

            _repository.Setup(x => x.FindByAsync(
                It.IsAny<Expression<Func<Cuenta, bool>>>()))
                .ReturnsAsync(cuenta);

            //Act
            var response = await _cmdHandler.Handle(_cmd, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
            response.Errors.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Handle_MontoLessOrEqualThanSaldoCuenta_ReturnOk()
        {
            //Arrange
            var cuenta = new Cuenta
            {
                Saldo = VALID_MONTO
            };

            _repository.Setup(x => x.FindByAsync(
                It.IsAny<Expression<Func<Cuenta, bool>>>()))
                .ReturnsAsync(cuenta);

            //Act
            var response = await _cmdHandler.Handle(_cmd, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Errors.Should().BeNullOrEmpty();

            _repository.Verify(x => x.SaveChangesAsync(),
                Times.Once);
        }

        [Fact]
        public async Task Handle_ExceptionThrown_ReturnInternalServerErrorAndErrorMessages()
        {
            //Arrange
            var cuenta = new Cuenta
            {
                Saldo = VALID_MONTO
            };

            _repository.Setup(x => x.FindByAsync(
                It.IsAny<Expression<Func<Cuenta, bool>>>()))
                .ThrowsAsync(new Exception());

            //Act
            var response = await _cmdHandler.Handle(_cmd, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.InternalServerError);
            response.Errors.Should().NotBeNullOrEmpty();
        }
    }
}
