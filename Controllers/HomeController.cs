using MaxDoseCheckerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MaxDoseCheckerMVC.Controllers
{
    public class HomeController : Controller
    {

        [ResponseCache(Duration = 5, Location = ResponseCacheLocation.Client, NoStore = false)]
        public IActionResult Index()
        {
            return View(Drug.GetDrugInfoFromCsv());
        }

        public IActionResult ProcessDrug(int? drugId, decimal? dose, string drugName, decimal? maxDose)
        {

            if (drugId != null && dose != null && drugName != null && maxDose != null)
            {

                var result = new
                {
                    drugId = drugId,
                    drugName = drugName,
                    dose = dose,
                    maxDose = maxDose,
                    maxDoseUtilisation = Drug.CalculateMaxDoseUtilisation(dose, maxDose),
                    errors = string.Empty
                };

                return Ok(result);
            }
            else
            {
                var result = new
                {
                    drugId = string.Empty,
                    drugName = string.Empty,
                    dose = string.Empty,
                    maxDose = maxDose,
                    maxDoseUtilisation = string.Empty,
                    errors = "Bad request"
                };

                return Ok(result);
            }

        }

        [ResponseCache(Duration = 5, Location = ResponseCacheLocation.Client, NoStore = false)]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 5, Location = ResponseCacheLocation.Client, NoStore = false)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
