using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restoransiparisyönsis.Data; 
using restoransiparisyönsis.Models;
using System.Security.Claims; 

namespace ProjeAdi.Controllers
{
    [Authorize]
    public class SiparisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiparisController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Olustur(int id)
        {
            var menu = await _context.Menuler.FindAsync(id);
            if (menu == null) return NotFound();

            ViewBag.EkstraMalzemeler = await _context.EkstraMalzemeler.ToListAsync();

            var siparis = new Siparis
            {
                MenuId = id,
                Menu = menu,
                Adet = 1 
            };

            return View(siparis);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Olustur(Siparis siparis, int[] selectedEkstraIds)
        {
            var menu = await _context.Menuler.FindAsync(siparis.MenuId);

            if (menu == null) return RedirectToAction("Index", "Home");

            decimal menuFiyati = menu.MenuFiyat;
            decimal ekstraFiyati = 0;
            if (selectedEkstraIds != null)
            {
                foreach (var ekstraId in selectedEkstraIds)
                {
                    var ekstra = await _context.EkstraMalzemeler.FindAsync(ekstraId);
                    if (ekstra != null)
                    {
                        ekstraFiyati += ekstra.EkstraMalzemeFiyat;
                    }
                }
            }
            siparis.ToplamTutar = (menuFiyati + ekstraFiyati) * siparis.Adet;
            siparis.SiparisTarihi = DateTime.Now;
            siparis.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            siparis.Id = 0; 
            siparis.Menu = null;

            _context.Add(siparis);
            await _context.SaveChangesAsync();

            return RedirectToAction("Onay");
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var siparisler = await _context.Siparisler
                                           .Include(s => s.Menu)
                                           .Where(s => s.UserId == userId)
                                           .OrderByDescending(s => s.SiparisTarihi)
                                           .ToListAsync();
            return View(siparisler);
        }
        public IActionResult Onay()
        {
            return View();
        }
    }
}