namespace EgyDynamic_Task.DTO
{
    public class PaginatedResult<T>
    {
        public int TotalItems { get; set; }
        public List<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
