using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TA.Starquest.Web.ViewModels;
using TA.Utils.Core.Diagnostics;

namespace TA.Starquest.Web.Controllers
    {
        public class HomeController : Controller
        {
            private readonly ILog log;

            public HomeController(ILog log)
            {
                this.log = log;
                log.Info().Message("Home controller").Write();
            }

            public IActionResult Index() => View();

        public IActionResult Privacy()
            {
            return View();
            }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
