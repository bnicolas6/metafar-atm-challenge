using Metafar.ATM.Challenge.Domain.QryResults;

namespace Metafar.ATM.Challenge.Application.UseCase.GetSaldo
{
    public class GetUsuarioQryResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static explicit operator GetUsuarioQryResponse(GetCuentaSaldoQryResult @object)
        {
            if (@object == null)
                throw new ArgumentNullException(nameof(@object));

            return new GetUsuarioQryResponse
            {
                Id = @object.UsuarioId,
                Nombre = @object.Nombre,
            };
        }
    }
}
