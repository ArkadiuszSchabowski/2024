using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Milionaires.Database;
using Milionaires.Models;
using System.Diagnostics;

namespace Milionaires.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _context;

        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Scores()
        {
            var scores = _context.Scores.OrderByDescending(s => s.Result).ToList();

            return View(scores);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

