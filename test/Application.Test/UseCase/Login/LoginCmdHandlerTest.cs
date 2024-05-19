using FluentAssertions;
using Metafar.ATM.Challenge.Application.UseCase.Login;
using Metafar.ATM.Challenge.Domain.Entities;
using Metafar.ATM.Challenge.Domain.Enums;
using Metafar.ATM.Challenge.Domain.Interfaces;
using Metafar.ATM.Challenge.Domain.Interfaces.Commands;
using Metafar.ATM.Challenge.Domain.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Linq.Expressions;
using System.Net;

namespace Application.Test.UseCase.Login
{
    public class LoginCmdHandlerTest
    {
        private readonly Mock<IMemoryCacheRepository> _memoryCacheRepository;
        private readonly Mock<IRepository<Cuenta>> _repository;
        private readonly Mock<ITokenGenerator> _tokenGenerator;
        private readonly Mock<IOptions<LoginSettings>> _options;
        private readonly Mock<ILogger<LoginCmdHandler>> _logger;

        private readonly LoginCmd _cmd;
        private readonly LoginCmdHandler _cmdHandler;

        private const string VALID_NUMERO_DE_TARJETA = "1122334455667788";
        private const string VALID_PIN = "1234";
        private const string ANOTHER_PIN = "5678";

        private const int NUMBER_OF_FAILED_ATTEMPTS_TO_BLOCK = 4;


        public LoginCmdHandlerTest()
        {
            _memoryCacheRepository = new Mock<IMemoryCacheRepository>();
            _repository = new Mock<IRepository<Cuenta>>();
            _tokenGenerator = new Mock<ITokenGenerator>();      
            _options = new Mock<IOptions<LoginSettings>>();
            _logger = new Mock<ILogger<LoginCmdHandler>>();

            _options.Setup(x => x.Value).Returns(
                new LoginSettings
                {
                    NumberOfFailedAttemptsToBlock = NUMBER_OF_FAILED_ATTEMPTS_TO_BLOCK
                });

            _cmdHandler = new LoginCmdHandler(
                _memoryCacheRepository.Object, 
                _repository.Object, 
                _tokenGenerator.Object, 
                _options.Object, 
                _logger.Object);

            _cmd = new LoginCmd(
                VALID_NUMERO_DE_TARJETA, 
                VALID_PIN);
        }

        [Fact]
        public async Task Handle_CuentaNotFound_ReturnBadRequestAndErrorMessage()
        {
            //Arrange
            Cuenta cuenta = null;
            _repository.Setup(x => x.FindByAsync(
                It.IsAny<Expression<Func<Cuenta, bool>>>()))
                .ReturnsAsync(cuenta);

            //Act
            var response = await _cmdHandler.Handle(_cmd, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
            response.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Handle_CuentaBlocked_ReturnForbiddenAndErrorMessage()
        {
            //Arrange
            Cuenta cuenta = new()
            {
                EstadoTarjetaId = (byte)EEstadoTarjeta.Bloqueado
            };

            _repository.Setup(x => x.FindByAsync(
                It.IsAny<Expression<Func<Cuenta, bool>>>()))
                .ReturnsAsync(cuenta);

            //Act
            var response = await _cmdHandler.Handle(_cmd, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.Forbidden);
            response.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Handle_FirstLoginAttemptFailed_ReturnUnauthorizedAndErrorMessage()
        {
            //Arrange
            _cmd.Pin = ANOTHER_PIN;

            Cuenta cuenta = new()
            {
                NumeroDeTarjeta = VALID_NUMERO_DE_TARJETA,
                Pin = VALID_PIN,
                EstadoTarjetaId = (byte)EEstadoTarjeta.Activo
            };

            _repository.Setup(x => x.FindByAsync(
                It.IsAny<Expression<Func<Cuenta, bool>>>()))
                .ReturnsAsync(cuenta);

            //Act
            var response = await _cmdHandler.Handle(_cmd, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.Unauthorized);
            response.Errors.Should().NotBeEmpty();

            _memoryCacheRepository.Verify(x => x.Insert(
                It.IsAny<object>(), 
                It.IsAny<LoginAttempts>()), 
                Times.Once());
        }

        [Fact]
        public async Task Handle_NewLoginAttemptFailed_ReturnUnauthorizedAndErrorMessage()
        {
            //Arrange
            _cmd.Pin = ANOTHER_PIN;

            Cuenta cuenta = new()
            {
                NumeroDeTarjeta = VALID_NUMERO_DE_TARJETA,
                Pin = VALID_PIN,
                EstadoTarjetaId = (byte)EEstadoTarjeta.Activo
            };

            var loginAttempts = new LoginAttempts
            {
                Attempts = 1
            };

            _repository.Setup(x => x.FindByAsync(
                It.IsAny<Expression<Func<Cuenta, bool>>>()))
                .ReturnsAsync(cuenta);

            _memoryCacheRepository.Setup(x => x.TryGetItem(
                It.IsAny<object>(), 
                out loginAttempts))
                .Returns(true);

            //Act
            var response = await _cmdHandler.Handle(_cmd, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.Unauthorized);
            response.Errors.Should().NotBeEmpty();

            _memoryCacheRepository.Verify(x => x.Update(
                It.IsAny<object>(),
                It.IsAny<LoginAttempts>()),
                Times.Once());
        }

        [Fact]
        public async Task Handle_MaximumLoginAttemptsFailed_ReturnForbiddenAndErrorMessage()
        {
            //Arrange
            _cmd.Pin = ANOTHER_PIN;

            Cuenta cuenta = new()
            {
                NumeroDeTarjeta = VALID_NUMERO_DE_TARJETA,
                Pin = VALID_PIN,
                EstadoTarjetaId = (byte)EEstadoTarjeta.Activo
            };

            var loginAttempts = new LoginAttempts
            {
                Attempts = NUMBER_OF_FAILED_ATTEMPTS_TO_BLOCK - 1
            };

            _repository.Setup(x => x.FindByAsync(
                It.IsAny<Expression<Func<Cuenta, bool>>>()))
                .ReturnsAsync(cuenta);

            _memoryCacheRepository.Setup(x => x.TryGetItem(
                It.IsAny<object>(),
                out loginAttempts))
                .Returns(true);

            //Act
            var response = await _cmdHandler.Handle(_cmd, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.Forbidden);
            response.Errors.Should().NotBeEmpty();

            _repository.Verify(x => x.Update(It.IsAny<Cuenta>()), Times.Once);
            _repository.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_LoginSuccess_ReturnOkAndToken()
        {
            //Arrange
            _cmd.Pin = VALID_PIN;
            var tokenExpected = "SoyUnToken";

            Cuenta cuenta = new()
            {
                NumeroDeTarjeta = VALID_NUMERO_DE_TARJETA,
                Pin = VALID_PIN,
                EstadoTarjetaId = (byte)EEstadoTarjeta.Activo
            };

            _repository.Setup(x => x.FindByAsync(
                It.IsAny<Expression<Func<Cuenta, bool>>>()))
                .ReturnsAsync(cuenta);

            _tokenGenerator.Setup(x => x.GenerateToken(
                It.IsAny<Dictionary<string, string>>()))
                .Returns(tokenExpected);

            //Act
            var response = await _cmdHandler.Handle(_cmd, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
            response.Content.Token.Should().Be(tokenExpected);

            _memoryCacheRepository.Verify(x => x.Delete(
                It.IsAny<object>()),
                Times.Once());
        }

        [Fact]
        public async Task Handle_ExceptionWasThrown_ReturnInternalServerErrorAndErrorMessage()
        {
            //Arrange

            _repository.Setup(x => x.FindByAsync(
                It.IsAny<Expression<Func<Cuenta, bool>>>()))
                .ThrowsAsync(new Exception());

            //Act
            var response = await _cmdHandler.Handle(_cmd, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.InternalServerError);
            response.Errors.Should().NotBeEmpty();
        }
    }
}
