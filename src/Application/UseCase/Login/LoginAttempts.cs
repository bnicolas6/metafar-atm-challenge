namespace Metafar.ATM.Challenge.Application.UseCase.Login
{
    public class LoginAttempts
    {
        public string NumeroDeTarjeta { get; set; }
        public int Attempts { get; set; } = 1;
    }
}
