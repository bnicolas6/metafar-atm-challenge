using FluentValidation.TestHelper;
using Metafar.ATM.Challenge.Application.UseCase.ExtractSaldo;

namespace Application.Test.UseCase.ExtractSaldo
{
    public class ExtractSaldoCmdValidatorTest
    {
        private readonly ExtractSaldoCmdValidator _validator;
        private readonly ExtractSaldoCmd _cmd;

        private const decimal VALID_MONTO = 475.25M;
        private const string NUMERO_DE_TARJETA = "1122334455667788";
        private const decimal INVALID_INTEGER_PART = 123456789123456.75M;

        public ExtractSaldoCmdValidatorTest()
        {
            _validator = new ExtractSaldoCmdValidator();

            _cmd = new ExtractSaldoCmd(
                NUMERO_DE_TARJETA, 
                VALID_MONTO);
        }

        [Fact]
        public void ExtractSaldoCmdValidator_MontoNotReceived_MustReturnValidationError()
        {
            //Arrange
            _cmd.Monto = null;

            //Act
            var result = _validator.TestValidate(_cmd);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Monto);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ExtractSaldoCmdValidator_MontoLessOrEqualThanZero_MustReturnValidationError(decimal monto)
        {
            //Arrange
            _cmd.Monto = monto;

            //Act
            var result = _validator.TestValidate(_cmd);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Monto);
        }

        [Fact]
        public void ExtractSaldoCmdValidator_MontoWithInvalidIntegerPart_MustReturnValidationError()
        {
            //Arrange
            _cmd.Monto = INVALID_INTEGER_PART;

            //Act
            var result = _validator.TestValidate(_cmd);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Monto);
        }
    }
}
