using DSTest.Models;
using DSTest.Services;
using DSTest.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSTest.Controllers
{
    public class MainController : Controller
    {
        private readonly FileService _fileService;
        private readonly MeasureService _measureService;
        public MainController(MeasureService measureService, FileService fileService) { 
            _fileService = fileService;
            _measureService = measureService;
        }
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Upload")]
        public IActionResult Upload()
        {
            return View();
        }
        [Route("Measures")]
        public async Task<IActionResult> Measures(string? year, string? month, int page = 1)
        {
            #region Определение пагинации

            int countPages = await _measureService.CountPages(year, month);

            if (page > countPages)
            {
                page = countPages;
            }

            MeasurePaginationViewModel paginationViewModel = new MeasurePaginationViewModel(countPages, page);

            #endregion

            List<WeatherMeasure> measures = await _measureService.GetMeasures(year, month, page);

            #region Определение фильтра

            List<string> availableYears = await _measureService.GetFilledYears();
            List<string> availableMonths = MonthsUtility.RussianDictionary.Keys.ToList();

            availableYears.Insert(0, "Все");
            availableMonths.Insert(0, "Все");

            MeasureFilterViewModel filterViewModel = new MeasureFilterViewModel(
                new SelectList(availableYears, year), 
                new SelectList(availableMonths, month),
                year,
                month
                );

            #endregion

            MeasurePageViewModel viewModel = new MeasurePageViewModel(measures, paginationViewModel, filterViewModel);

            return View(viewModel);
        }
        [HttpPost]
        [Route("UploadFile")]
        public async Task<IActionResult> UploadFile(IEnumerable<IFormFile> files)
        {
            if (files.Count() == 0)
            {
                ViewBag.UploadError = "Осутствуют файлы в запросе!";
                return View("Upload");
            }
            

            if (!_fileService.CheckFileNameExtention(files))
            {
                ViewBag.UploadError = "Недопустимые расширения файлов!";
                return View("Upload");
            }

            try
            {
                List<WeatherMeasure> measures = _fileService.ParseEcxelFiles(files);

                await _measureService.AddMeasuresRangeToDb(measures);
            }
            catch (Exception)
            {
                ViewBag.UploadError = "Что-то пошло не так во время проверки файлов";
                return View("Upload");
            }
            

            ViewBag.UploadSucces = true;

            return View("Upload");
        }
    }
}
