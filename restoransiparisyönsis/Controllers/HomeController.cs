using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restoransiparisyönsis.Data; 
using restoransiparisyönsis.Models;
using System.Diagnostics;

namespace restoransiparisyönsis.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Hakkimizda()
        {
            return View();
        }
        private readonly ILogger<HomeController> _logger;
        
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var menuler = await _context.Menuler.ToListAsync();
            return View(menuler);
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