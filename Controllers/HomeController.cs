using MaxDoseCheckerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using MaxDoseCheckerMVC.Calculation;

namespace MaxDoseCheckerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 5, Location = ResponseCacheLocation.Client, NoStore = false)]
        public IActionResult Index()
        {
           var drugList = Drugs.GetDrugInfoFromCsv();

            return View(drugList);
        }
       
        [HttpPost]
        public IActionResult ProcessSubmittedDoses()
        {
            return View();   
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
