namespace RubberWeb.Models
{
    public class PaginatedRequest
    {
        public int Limit { get; set; } = 100;
        public int Page { get; set; } = 1;
        public PageSort Sort { get; set; } = PageSort.Desc;
    }
}
