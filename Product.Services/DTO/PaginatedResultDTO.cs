namespace Product.Services.DTO
{
    public class PaginatedResultDTO<T>
    {
        public PaginatedResultDTO(int pageIndex,int pageSize,int totalCount,IReadOnlyList<T> data)
            {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            Data = data;
            }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IReadOnlyList<T> Data { get;}
    }
}
