using DSTest.Models;
using DSTest.Utility;

namespace DSTest.Extensions
{
    public static class WeatherMeasureExtension
    {
        public static IQueryable<WeatherMeasure> ApplyYearFilter(this IQueryable<WeatherMeasure> query, string? year)
        {
            bool isValidYear = int.TryParse(year, out int _year);

            if (year == null || year == "Все" || !isValidYear)
            {
                return query;
            }

            return query
                .Where(x => x.Date.Year == _year);
        }

        public static IQueryable<WeatherMeasure> ApplyMonthFilter(this IQueryable<WeatherMeasure> query, string? month)
        {
            if (month == null || !MonthsUtility.RussianDictionary.ContainsKey(month))
            {
                return query;
            }

            var _month = MonthsUtility.RussianDictionary[month];

            return query
                .Where(x => x.Date.Month == _month);
        }
    }
}
