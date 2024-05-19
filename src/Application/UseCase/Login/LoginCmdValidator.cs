using FluentValidation;
using Metafar.ATM.Challenge.Common;
using Metafar.ATM.Challenge.Common.ErrorMessages;

namespace Metafar.ATM.Challenge.Application.UseCase.Login
{
    public class LoginCmdValidator : AbstractValidator<LoginCmd>
    {
        public LoginCmdValidator()
        {
            RuleFor(cuenta => cuenta.NumeroDeTarjeta)
                 .Cascade(CascadeMode.Stop)

                 .Must(numero => !string.IsNullOrWhiteSpace(numero))
                 .WithMessage(string.Format(
                    CommonErrorMessage.IS_REQUIRED,
                    "{PropertyName}"))

                 .Must(numero => numero.Length == Constants.NUMERO_DE_TARJETA_LENGTH)
                 .WithMessage(x => string.Format(
                     CommonErrorMessage.INVALID_LENGTH,
                     nameof(x.NumeroDeTarjeta),
                     Constants.NUMERO_DE_TARJETA_LENGTH,
                     x.NumeroDeTarjeta.Length))

                 .Must(numero => numero.All(char.IsDigit))
                 .WithMessage(string.Format(
                    CommonErrorMessage.ONLY_NUMERIC_CHARACTERS,
                    "{PropertyName}"));


            RuleFor(cuenta => cuenta.Pin)
                 .Cascade(CascadeMode.Stop)

                 .Must(pin => !string.IsNullOrWhiteSpace(pin))
                 .WithMessage(string.Format(
                    CommonErrorMessage.IS_REQUIRED,
                    "{PropertyName}"))

                 .Must(pin => pin.Length == Constants.PIN_LENGTH)
                 .WithMessage(x => string.Format(
                     CommonErrorMessage.INVALID_LENGTH,
                     nameof(x.Pin),
                     Constants.PIN_LENGTH,
                     x.Pin.Length))

                 .Must(pin => pin.All(char.IsDigit))
                 .WithMessage(string.Format(
                    CommonErrorMessage.ONLY_NUMERIC_CHARACTERS,
                    "{PropertyName}"));
        }
    }
}
