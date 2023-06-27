using DSTest.Models;
using Npoi.Mapper;
using Org.BouncyCastle.Asn1.X509;
using System.Globalization;

namespace DSTest.Helpers
{
    public static class ExcelHelper
    {
        /// <summary>
        /// Функция для NPOI.Mapper, парсит значение ячейки в DateOnly
        /// </summary>
        /// <param name="column"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool DateOnlyTakeResolver(IColumnInfo column, object target)
        {
            if (column.CurrentValue == null) return false;

            bool isValidDate = DateTime.TryParseExact(
                column.CurrentValue.ToString(),
                "dd.MM.yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime value);

            if (!isValidDate) return false;

            ((WeatherMeasure)target).Date = DateOnly.FromDateTime(value.Date);
            return true;
        }
        /// <summary>
        /// Функция для NPOI.Mapper, парсит значение ячейки в TimeOnly
        /// </summary>
        /// <param name="column"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool TimeOnlyTakeResolver(IColumnInfo column, object target)
        {
            if (column.CurrentValue == null) return false;

            bool isValidDate = DateTime.TryParseExact(
                column.CurrentValue.ToString(),
                "HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime value);

            if (!isValidDate) return false;

            ((WeatherMeasure)target).MoscowTime = TimeOnly.FromDateTime(value);
            return true;
        }
    }
}
