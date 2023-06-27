using DSTest.Helpers;
using DSTest.Models;
using Npoi.Mapper;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Asn1.X509;
using System.Globalization;

namespace DSTest.Services
{
    public class FileService
    {
        /// <summary>
        /// Возрващает true, если все файлы с раширениями .xsl или .xslx
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public bool CheckFileNameExtention(IEnumerable<IFormFile> files)
        {
            return files.All(f =>
            {
                var extension = Path.GetExtension(f.FileName);

                return extension == ".xsl" || extension == ".xlsx";
            });
        }
        /// <summary>
        /// Парсит файлы
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public List<WeatherMeasure> ParseEcxelFiles(IEnumerable<IFormFile> files)
        {
            List<WeatherMeasure> weatherMeasures = new List<WeatherMeasure>();

            foreach (var file in files)
            {
                weatherMeasures.AddRange(BookToListOfMeasures(file));
            }

            return weatherMeasures;

        }
        /// <summary>
        /// Парсит книгу excel
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="Exception">Ошибка при распознавании файла</exception>
        private List<WeatherMeasure> BookToListOfMeasures(IFormFile file)
        {
            using(Stream stream = file.OpenReadStream())
            {
                var mapper = new Mapper(stream);
                List<WeatherMeasure> result = new List<WeatherMeasure>();

                mapper.FirstRowIndex = 4;
                mapper.HasHeader = false;
                mapper.Map<WeatherMeasure>(0, m => m.Date, ExcelHelper.DateOnlyTakeResolver);
                mapper.Map<WeatherMeasure>(1, m => m.MoscowTime, ExcelHelper.TimeOnlyTakeResolver);

                for (int sheetIndex = 0; sheetIndex < mapper.Workbook.NumberOfSheets; sheetIndex++)
                {
                    var mappedList = mapper
                        .Take<WeatherMeasure>(sheetIndex);

                    if (mappedList.Any(item => item.ErrorMessage != null))
                    {
                        var error = mappedList.First(i => i.ErrorMessage != null);
                        throw new Exception(mappedList.First(i => i.ErrorMessage != null).ErrorColumnIndex.ToString());
                    }

                    result.AddRange(
                        mappedList
                            .Select(item => item.Value)
                            .ToList()
                        );
                }

                return result;
            }
        }
      
    }
}
