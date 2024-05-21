using FluentValidation;
using Metafar.ATM.Challenge.Common.ErrorMessages;

namespace Metafar.ATM.Challenge.Application.UseCase.GetOperaciones
{
    public class GetOperacionQryValidator : AbstractValidator<GetOperacionQry>
    {
        public GetOperacionQryValidator()
        {
            RuleFor(x => x.PageNumber)
                 .Cascade(CascadeMode.Stop)

                .Must(x => x > default(int))
                .WithMessage(string.Format(
                    CommonErrorMessage.INVALID_VALUE_SIZE,
                    "{PropertyName}", default(int)))
                .When(x => x.PageNumber.HasValue);
        }
    }
}
