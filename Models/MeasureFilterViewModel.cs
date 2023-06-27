using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSTest.Models
{
    public class MeasureFilterViewModel
    {
        public MeasureFilterViewModel(
                SelectList years,
                SelectList months,
                string? selectedYear,
                string? selectedMonth
            ) 
        { 
            Years = years;
            Months = months;
            SelectedYear = selectedYear;
            SelectedMonth = selectedMonth;
        }
        
        public SelectList Years { get; set; }
        public SelectList Months { get; set; }
        public string? SelectedYear { get; set; }
        public string? SelectedMonth { get; set; }
    }
}
