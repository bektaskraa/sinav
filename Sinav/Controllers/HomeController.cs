using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sinav.Models;
using System.Diagnostics;

namespace Sinav.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        SinavContext db = new SinavContext();

        public IActionResult Index()
        {
            ViewModel wm = new ViewModel();
            wm.urunler = db.Urunlers.ToList();
            wm.renk = db.Renks.ToList();
            wm.boyut = db.Boyuts.ToList();
            return View(wm);
        }

        public IActionResult Detay(int id)
        {
			var urun = db.Urunlers.Include(x=> x.Color).Include(y => y.Size).FirstOrDefault(x => x.Id == id);
			return View(urun);
        }

		public IActionResult Create()
		{
			ViewData["ColorId"] = new SelectList(db.Renks, "Id", "Id");
			ViewData["SizeId"] = new SelectList(db.Boyuts, "Id", "Id");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Ad,Aciklama,Fiyat,SizeId,ColorId")] Urunler urunler)
		{
			if (ModelState.IsValid)
			{
				db.Add(urunler);
				await db.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["ColorId"] = new SelectList(db.Renks, "Id", "Id", urunler.ColorId);
			ViewData["SizeId"] = new SelectList(db.Boyuts, "Id", "Id", urunler.SizeId);
			return View(urunler);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}