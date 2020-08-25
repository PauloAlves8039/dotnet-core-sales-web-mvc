using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    /// <summary>
    /// Controlador responsável pela pesquisa dos registros das vendas.
    /// </summary>
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action responsável por pesquisa simpes de venda por data.
        /// </summary>
        /// <param name="minDate">Define uma data mínima para a pesquisa.</param>
        /// <param name="maxDate">Define uma data maxima para a pesquisa.</param>
        /// <returns>Registro da venda de acordo com a data especificada.</returns>
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue) 
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue) 
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        /// <summary>
        /// Action responsável por pesquisa de grupo de vendas por data.
        /// </summary>
        /// <param name="minDate">Define uma data mínima para a pesquisa.</param>
        /// <param name="maxDate">Define uma data maxima para a pesquisa.</param>
        /// <returns>Registro de um grupo de vendas de acordo com a data especificada.</returns>
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
