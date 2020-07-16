using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PasswordGenerator.Classes;
using PasswordGenerator.Models;

namespace PasswordGenerator.Controllers
{
    public class HomeController : Controller
    {
        protected IOptions<AppSettings> _config;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            ViewData["MinChar"] = _config.Value.MinChar;
            ViewData["MinLC"] = _config.Value.MinLC;
            ViewData["MinUC"] = _config.Value.MinUC;
            ViewData["MinNum"] = _config.Value.MinUC;
            ViewData["MinSp"] = _config.Value.MinSp;

            Password password = new Password()
            {
                MinChar = _config.Value.MinChar,
                MinLC = _config.Value.MinLC,
                MinUC = _config.Value.MinUC,
                MinNum = _config.Value.MinNum,
                MinSp = _config.Value.MinSp,
                MaxChar = null
            };

            return View(password);
        }

        [HttpPost, ActionName("Index")]
        public IActionResult GeneratePassword(Password password)
        {
            ViewData["MinChar"] = _config.Value.MinChar;
            ViewData["MinLC"] = _config.Value.MinLC;
            ViewData["MinUC"] = _config.Value.MinUC;
            ViewData["MinNum"] = _config.Value.MinUC;
            ViewData["MinSp"] = _config.Value.MinSp;

            Generator.Generate(password);

            return View(password);
        }

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
