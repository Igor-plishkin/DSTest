namespace DSTest.Models
{
    public class MeasurePaginationViewModel
    {
        public int PageNumber { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public MeasurePaginationViewModel(int totalPages, int pageNumber)
        {
            PageNumber = pageNumber;
            TotalPages = totalPages;
        }
    }
}
