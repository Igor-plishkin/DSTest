using DSTest.Extensions;
using DSTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DSTest.Services
{
    public class MeasureService
    {
        private readonly ApplicationContext _dbContext;
        public MeasureService(ApplicationContext context) { 
            _dbContext = context;
        }
        /// <summary>
        /// Сохраняет в базу список измерений
        /// </summary>
        /// <param name="measures"></param>
        public async Task AddMeasuresRangeToDb(List<WeatherMeasure> measures)
        {
            await _dbContext.AddRangeAsync(measures);

            await _dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// Возвращает список годов для заполненных данных
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetFilledYears()
        {
            return await _dbContext.WeatherMeasures
                .GroupBy(m => m.Date.Year)
                .Select(m => m.Key.ToString())
                .ToListAsync();
        }
        /// <summary>
        /// Получение списка измерений, размер страницы задан поумолчанию 10 измерений
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<List<WeatherMeasure>> GetMeasures(string? year, string? month, int page = 1)
        {
            return await _dbContext.WeatherMeasures
                .ApplyYearFilter(year)
                .ApplyMonthFilter(month)
                .OrderBy(m => m.Date)
                .ThenBy(m => m.MoscowTime)
                .Skip((page - 1) * 10)
                .Take(10)
                .ToListAsync();
        }
        /// <summary>
        /// Возвращает количество страниц с указанными фильтрами,
        /// если найденых элементов 0, возвращает 1
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<int> CountPages(string? year, string? month)
        {
            int count = await _dbContext.WeatherMeasures
                .ApplyYearFilter(year)
                .ApplyMonthFilter(month)
                .CountAsync();

            return count > 0 ? (int)Math.Ceiling(count / (double)10) : 1;
        }
    }
}
