using Metafar.ATM.Challenge.Domain.Entities;
using Metafar.ATM.Challenge.Domain.Enums;
using System.Net.NetworkInformation;
using System.Transactions;

namespace Metafar.ATM.Challenge.Application.UseCase.ExtractSaldo.Response
{
    public class TipoOperacionCmdResponse
    {
        public byte Id { get; set; }
        public string Descripcion { get; set; }

        public static explicit operator TipoOperacionCmdResponse(Operacion @object)
        {
            if (@object == null)
                throw new ArgumentNullException(nameof(@object));

            return new TipoOperacionCmdResponse
            {
                Id = @object.TipoOperacionId,
                Descripcion = EnumHelper.GetEnumDescription<ETipoOperacion>(@object.TipoOperacionId)
            };
        }
    }
}
