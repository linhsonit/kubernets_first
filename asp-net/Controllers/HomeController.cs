using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using asp_net.Models;
using StackExchange.Redis;

namespace asp_net.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDatabase _database;

        public HomeController(ILogger<HomeController> logger, IDatabase database)
        {
            _logger = logger;
            _database = database;
        }

        public IActionResult Index()
        {
            string count = _database.StringGet("count");

            _database.StringSet("count", count != null ? Convert.ToInt32(count) + 1 : 0);

            return View("index", _database.StringGet("count"));
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
