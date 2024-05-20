using FluentValidation;
using Metafar.ATM.Challenge.Common;
using Metafar.ATM.Challenge.Common.ErrorMessages;
using Metafar.ATM.Challenge.Common.Utils;

namespace Metafar.ATM.Challenge.Application.UseCase.ExtractSaldo
{
    public class ExtractSaldoCmdValidator : AbstractValidator<ExtractSaldoCmd>
    {
        public ExtractSaldoCmdValidator()
        {
            RuleFor(x => x.Monto)
                .Cascade(CascadeMode.Stop)

                .Must(x => x.HasValue)
                .WithMessage(string.Format(
                    CommonErrorMessage.IS_REQUIRED_VALUE,
                    "{PropertyName}"))

                .Must(x => x > default(decimal))
                .WithMessage(string.Format(
                    CommonErrorMessage.INVALID_VALUE_SIZE,
                    "{PropertyName}", default(decimal)))

                .Must(x => x.Value.IsValidIntegerPart())
                .WithMessage(string.Format(
                    CommonErrorMessage.INVALID_DECIMAL_INTEGER_PART,
                    "{PropertyName}", Constants.DECIMAL_INTEGER_VALUE));
        }
    }
}
