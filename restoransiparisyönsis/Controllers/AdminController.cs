using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restoransiparisyönsis.Data; 
using restoransiparisyönsis.Models;

namespace restoransiparisyönsis.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            decimal toplamCiro = await _context.Siparisler.SumAsync(s => s.ToplamTutar);

            int siparisSayisi = await _context.Siparisler.CountAsync();

            var popullerMenu = await _context.Siparisler
                .Include(s => s.Menu)
                .GroupBy(s => s.Menu.MenuAd)
                .OrderByDescending(g => g.Count())
                .Select(g => new { Ad = g.Key, Sayi = g.Count() })
                .FirstOrDefaultAsync();

            ViewBag.ToplamCiro = toplamCiro;
            ViewBag.SiparisSayisi = siparisSayisi;
            ViewBag.PopulerMenu = popullerMenu?.Ad ?? "Henüz Yok";

            return View();
        }
        public async Task<IActionResult> TumSiparisler()
        {
            var siparisler = await _context.Siparisler
                                           .Include(s => s.Menu)
                                           .OrderByDescending(s => s.SiparisTarihi)
                                           .ToListAsync();
            return View(siparisler);
        }
        public IActionResult Kullanicilar()
        {
            var kullanicilar = _context.Users.ToList();
            return View(kullanicilar);
        }
    }
}
