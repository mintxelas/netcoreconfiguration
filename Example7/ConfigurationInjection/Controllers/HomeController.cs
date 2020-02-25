using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConfigurationInjection.Models;
using Microsoft.Extensions.Options;

namespace ConfigurationInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ExternalApiConfiguration configuration;
        private readonly ExternalApiConfiguration configurationSnapshot;

        public HomeController(IOptions<ExternalApiConfiguration> options, IOptionsSnapshot<ExternalApiConfiguration> optionsSnapshot)
        {
            configuration = options.Value;
            configurationSnapshot = optionsSnapshot.Value;
        }

        public IActionResult Index()
        {
            ViewBag.Message = configuration.ClientId;
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Message = configurationSnapshot.ClientId;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
