using FluentAssertions;
using FluentValidation.TestHelper;
using Metafar.ATM.Challenge.Application.UseCase.GetOperaciones;

namespace Application.Test.UseCase.GetOperaciones
{
    public class GetOperacionQryValidatorTest
    {
        private GetOperacionQry _qry;
        private GetOperacionQryValidator _validator;

        private const string NUMERO_DE_TARJETA = "1122334455667788";
        private const int VALID_PAGE_NUMBER = 1;

        public GetOperacionQryValidatorTest()
        {
            _validator = new GetOperacionQryValidator();

            _qry = new GetOperacionQry(
                NUMERO_DE_TARJETA, 
                VALID_PAGE_NUMBER);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetOperacionQryValidator_InvalidPageNumber_ReturnBadRequestAndErrorMessage(int pageNumber)
        {
            //Arrange
            _qry.PageNumber = pageNumber;

            //Act
            var result = _validator.TestValidate(_qry);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.PageNumber);
        }
    }
}
