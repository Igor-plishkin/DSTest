using Npoi.Mapper.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DSTest.Models
{
    public class WeatherMeasure
    {
        [Key]
        [Ignore]
        public int Id { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        [Column(0)]
        public DateOnly Date { get; set; }
        /// <summary>
        /// Время московское
        /// </summary>
        [Column(1)]
        public TimeOnly MoscowTime { get; set; }
        /// <summary>
        /// Температура воздуха
        /// </summary>
        [Column(2)]
        public float Temperature { get; set; }
        /// <summary>
        /// Относительная влажность воздуха
        /// </summary>
        [Column(3)]
        public float AirHumidity { get; set; }
        /// <summary>
        /// Точка росы (Td)
        /// </summary>
        [Column(4)]
        public float DewPoint { get; set; }
        /// <summary>
        /// Атм. давление
        /// </summary>
        [Column(5)]
        public int Pressure { get; set; }
        /// <summary>
        /// Направление ветра
        /// </summary>
        [Column(6)]
        public string? WindDirection { get; set; }
        /// <summary>
        /// Скорость ветра
        /// </summary>
        [Column(7)]
        public int? WindSpeed { get; set; }
        /// <summary>
        /// Облачность
        /// </summary>
        [Column(8)]
        public int? Cloudiness { get; set; }
        /// <summary>
        /// Нижняя граница облачности
        /// </summary>
        [Column(9)]
        public int? LowCloudiness { get; set; }
        /// <summary>
        /// Горизонтальная видимость (VV)
        /// </summary>
        [Column(10)]
        public string? HorizontalVisibility { get; set; }
        /// <summary>
        /// Погодные явления
        /// </summary>
        [Column(11)]
        public string? WeatherConditions { get; set; }
    }
}
