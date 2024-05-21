using Metafar.ATM.Challenge.Domain.QryResults;

namespace Metafar.ATM.Challenge.Application.UseCase.GetOperaciones.Response
{
    public class GetOperacionQryResponse
    {
        public int Id { get; set; }
        public TipoOperacionQryResponse TipoOperacion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }

        public static explicit operator GetOperacionQryResponse(GetOperacionQryResult @object)
        {
            if (@object == null) 
                throw new ArgumentNullException(nameof(@object));

            return new GetOperacionQryResponse
            {
                Id = @object.Id,
                TipoOperacion = (TipoOperacionQryResponse)@object,
                Fecha = @object.Fecha,
                Monto = @object.Monto
            };
        }
    }
}