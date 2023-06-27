namespace DSTest.Models
{
    public class MeasurePageViewModel
    {
        public MeasurePageViewModel(
                IEnumerable<WeatherMeasure> measures,
                MeasurePaginationViewModel paginationViewModel,
                MeasureFilterViewModel filterViewModel
            ) {
            Measures = measures;
            PaginationViewModel = paginationViewModel;
            FilterViewModel = filterViewModel;
        }
        public IEnumerable<WeatherMeasure> Measures { get; }
        public MeasurePaginationViewModel PaginationViewModel { get; }
        public MeasureFilterViewModel FilterViewModel { get;}
    }
}
