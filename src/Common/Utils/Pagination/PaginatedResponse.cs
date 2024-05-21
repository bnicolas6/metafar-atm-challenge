namespace Metafar.ATM.Challenge.Common.Utils.Pagination
{
    public class PaginatedResponse
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalRows { get; set; }

        public PaginatedResponse(
            int pageSize, 
            int pageNumber, 
            int totalRows)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalRows = totalRows;
        }
    }
}
