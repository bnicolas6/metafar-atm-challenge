using Metafar.ATM.Challenge.Common.Utils.Pagination;

namespace Metafar.ATM.Challenge.Application.UseCase.GetOperaciones.Response
{
    public class GetOperacionesQryResponse : PaginatedResponse
    {
        public List<GetOperacionQryResponse> Operaciones { get; set; }

        public GetOperacionesQryResponse(
            List<GetOperacionQryResponse> operaciones, 
            int pageSize, 
            int pageNumber,
            int totalRows)
            :base(pageSize, pageNumber, totalRows)
        {
            Operaciones = operaciones;
        }
    }
}
