namespace Metafar.ATM.Challenge.Domain.QryResults
{
    public class GetOperacionQryResult
    {
        public int Id { get; set; }
        public byte TipoOperacionId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
    }
}
