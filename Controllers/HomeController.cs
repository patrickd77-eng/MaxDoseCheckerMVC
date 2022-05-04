using MaxDoseCheckerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MaxDoseCheckerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(Drugs.GetDrugInfoFromCsv());
        }

        public IActionResult AddToList(string drug, string dose)
        {  

            if (drug != null && dose != null)
            {
                var result = new
                {
                    drug = drug.Trim(),
                    dose = dose.Trim(),
                    errors = string.Empty
                };

                return Ok(result);
            }
            else
            {
                var result = new
                {
                    drug = string.Empty,
                    dose = string.Empty,
                    errors = "Bad request"
                };

                return Ok(result);
            }

        }

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
