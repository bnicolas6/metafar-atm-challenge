using Metafar.ATM.Challenge.Domain.Enums;
using Metafar.ATM.Challenge.Domain.QryResults;

namespace Metafar.ATM.Challenge.Application.UseCase.GetOperaciones.Response
{
    public class TipoOperacionQryResponse
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        
        public static explicit operator TipoOperacionQryResponse(GetOperacionQryResult @object)
        {
            if (@object == null) 
                throw new ArgumentNullException(nameof(@object));

            return new TipoOperacionQryResponse
            {
                Id = @object.TipoOperacionId,
                Descripcion = EnumHelper.GetEnumDescription<ETipoOperacion>(@object.TipoOperacionId)
            };

        }
    }
}
