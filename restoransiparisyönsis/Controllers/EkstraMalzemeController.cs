using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restoransiparisyönsis.Data;
using restoransiparisyönsis.Models;

namespace restoransiparisyönsis.Controllers
{
    public class EkstraMalzemeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EkstraMalzemeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.EkstraMalzemeler.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EkstraMalzeme ekstra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ekstra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ekstra);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var malzeme = await _context.EkstraMalzemeler.FindAsync(id);
            if(malzeme != null)
            {
                _context.EkstraMalzemeler.Remove(malzeme);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
