namespace Domain.Models.PageModels
{
    public class PaginatedResult<T>
    {
        public int PageNumber { get; set; }
        public long TotalPages { get; set; }
        public int PageSize { get; set; }
        public long TotalRecords { get; set; }
        public IReadOnlyCollection<T> Data { get; set; }

        public PaginatedResult(IReadOnlyCollection<T> data, int pageNumber, int pageSize, long totalRecords)
        {
            PageNumber = pageNumber;
            TotalPages = totalRecords;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
            Data = data;
        }
    }
}
