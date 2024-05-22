using Bogus;
using FluentAssertions;
using Metafar.ATM.Challenge.Application.UseCase.GetOperaciones;
using Metafar.ATM.Challenge.Domain.Enums;
using Metafar.ATM.Challenge.Domain.Interfaces.Queries;
using Metafar.ATM.Challenge.Domain.QryResults;
using Metafar.ATM.Challenge.Domain.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Net;
using System.Runtime.CompilerServices;

namespace Application.Test.UseCase.GetOperaciones
{
    public class GetOperacionQryHandlerTest
    {
        private readonly Mock<IOperacionesQuery> _operacionesQuery;
        private readonly Mock<ILogger<GetOperacionQryHandler>> _logger;
        private readonly Mock<IOptions<PaginationSettings>> _options;

        private readonly GetOperacionQryHandler _qryHandler;
        private readonly GetOperacionQry _qry;
        private readonly PaginationSettings _paginationSettings;

        private const string NUMERO_DE_TARJETA = "1122334455667788";

        private const int PAGE_SIZE = 25;
        private const int PAGE_NUMBER = 5;
        private const int DEFAULT_PAGE_NUMBER = 3;
        private const int TOTAL_ROWS = 15;

        public GetOperacionQryHandlerTest()
        {
            _operacionesQuery = new();
            _logger = new();
            _options = new();

            _paginationSettings = new PaginationSettings
            {
                PageSize = PAGE_SIZE,
                DefaultPageNumber = DEFAULT_PAGE_NUMBER
            };

            _options.Setup(x => x.Value).Returns(_paginationSettings);

            _qryHandler = new GetOperacionQryHandler(
                _operacionesQuery.Object,
                _options.Object,
                _logger.Object);

            _qry = new GetOperacionQry(
                NUMERO_DE_TARJETA,
                PAGE_NUMBER);
        }

        [Fact]
        public async Task Handle_PageNumberReceived_UsePageNumberReceived()
        {
            //Arrange
            _qry.PageNumber = PAGE_NUMBER;
            var totalRowsExpected = 8;

            _operacionesQuery.Setup(x => x.GetOperacionesAsync(
                It.IsAny<string>(), 
                It.IsAny<int>(), 
                It.IsAny<int>()))
                .ReturnsAsync((GenerateFakeItems(totalRowsExpected), totalRowsExpected));

            //Act
            var response = await _qryHandler.Handle(_qry, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.PageNumber.Should().Be(_qry.PageNumber);
            response.Content.PageSize.Should().Be(_paginationSettings.PageSize);
            response.Content.TotalRows.Should().Be(totalRowsExpected);
        }

        [Fact]
        public async Task Handle_PageNumberNotReceived_UseDefaultPageNumber()
        {
            //Arrange
            _qry.PageNumber = null;
            _operacionesQuery.Setup(x => x.GetOperacionesAsync(
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<int>()))
                .ReturnsAsync((GenerateFakeItems(default), TOTAL_ROWS));

            //Act
            var response = await _qryHandler.Handle(_qry, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.PageNumber.Should().Be(_paginationSettings.DefaultPageNumber);
            response.Content.PageSize.Should().Be(_paginationSettings.PageSize);
            response.Content.TotalRows.Should().Be(TOTAL_ROWS);
        }

        [Fact]
        public async Task Handle_OverflowExceptionThrown_ReturnInternalServerErrorAndErrorMessage()
        {
            //Arrange
            _qry.PageNumber = null;
            _operacionesQuery.Setup(x => x.GetOperacionesAsync(
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<int>()))
                .Throws(new OverflowException());

            //Act
            var response = await _qryHandler.Handle(_qry, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.InternalServerError);
            response.Errors.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Handle_ExceptionThrown_ReturnInternalServerErrorAndErrorMessage()
        {
            //Arrange
            _qry.PageNumber = null;
            _operacionesQuery.Setup(x => x.GetOperacionesAsync(
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<int>()))
                .Throws(new Exception());

            //Act
            var response = await _qryHandler.Handle(_qry, CancellationToken.None);

            //Assert
            response.HttpStatusCode.Should().Be(HttpStatusCode.InternalServerError);
            response.Errors.Should().NotBeNullOrEmpty();
        }



        private IEnumerable<GetOperacionQryResult> GenerateFakeItems(int total)
        {
            var faker = new Faker<GetOperacionQryResult>()
                    .RuleFor(x => x.Id, f => f.Random.Int())
                    .RuleFor(x => x.TipoOperacionId, f => (byte)f.PickRandom<ETipoOperacion>())
                    .RuleFor(x => x.Fecha, f => f.Date.Past())
                    .RuleFor(x => x.Monto, f => f.Random.Decimal());
            
            return faker.Generate(total);
        }

    }
}