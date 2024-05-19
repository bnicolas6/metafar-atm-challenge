using FluentValidation.TestHelper;
using Metafar.ATM.Challenge.Application.UseCase.Login;

namespace Application.Test.UseCase.Login
{
    public class LoginCmdValidatorTest
    {
        private readonly LoginCmdValidator _validator;
        private readonly LoginCmd _cmd;

        private const string VALID_NUMERO_DE_TARJETA = "1122334455667788";
        private const string VALID_PIN = "1234";

        public LoginCmdValidatorTest()
        {
            _validator = new LoginCmdValidator();

            _cmd = new LoginCmd(
                VALID_NUMERO_DE_TARJETA, 
                VALID_PIN);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void LoginCmdValidator_NumeroDeTarjetaIsNotReceived_MustReturnValidationError(string numeroDeTarjeta)
        {
            //Arrange
            _cmd.NumeroDeTarjeta = numeroDeTarjeta;

            //Act
            var result = _validator.TestValidate(_cmd);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.NumeroDeTarjeta);
        }

        [Theory]
        [InlineData("112233445566778")]
        [InlineData("11223344556677889")]
        public void LoginCmdValidator_NumeroDeTarjetaHasInvalidLength_MustReturnValidationError(string numeroDeTarjeta)
        {
            //Arrange
            _cmd.NumeroDeTarjeta = numeroDeTarjeta;

            //Act
            var result = _validator.TestValidate(_cmd);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.NumeroDeTarjeta);
        }


        [Theory]
        [InlineData("A122334B5566778C")]
        [InlineData("ABCDEFGHJKLMNOPQ")]
        public void LoginCmdValidator_NumeroDeTarjetaIsNotNumeric_MustReturnValidationError(string numeroDeTarjeta)
        {
            //Arrange
            _cmd.NumeroDeTarjeta = numeroDeTarjeta;

            //Act
            var result = _validator.TestValidate(_cmd);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.NumeroDeTarjeta);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void LoginCmdValidator_PinIsNotReceived_MustReturnValidationError(string pin)
        {
            //Arrange
            _cmd.Pin = pin;

            //Act
            var result = _validator.TestValidate(_cmd);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Pin);
        }


        [Theory]
        [InlineData("123")]
        [InlineData("12345")]
        public void LoginCmdValidator_PinHasInvalidLength_MustReturnValidationError(string pin)
        {
            //Arrange
            _cmd.Pin = pin;

            //Act
            var result = _validator.TestValidate(_cmd);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Pin);
        }

        [Theory]
        [InlineData("A23B")]
        [InlineData("ABCD")]
        public void LoginCmdValidator_PinIsNotNumeric_MustReturnValidationError(string pin)
        {
            //Arrange
            _cmd.Pin = pin;

            //Act
            var result = _validator.TestValidate(_cmd);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Pin);
        }
    }
}
