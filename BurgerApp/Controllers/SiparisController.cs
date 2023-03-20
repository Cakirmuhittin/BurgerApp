using BurgerApp.Areas.Identity.Data;
using BurgerApp.Data;
using BurgerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.Controllers
{
    //[Authorize(Roles ="Musteri,Yonetici")]
    public class SiparisController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SiparisController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: SiparisController
        public ActionResult Index()
        {
            return View(_db.Menuler.ToList());
        }

        public IActionResult Extra(int id)
        {
            Menu? menu = _db.Menuler.Find(id);
            ViewBag.Menu = menu!.MenuAdi;
            ViewBag.Fiyat =menu.Fiyat;
            ViewBag.Resim=menu.Resim;
            TempData["id"] = id;

            return View(_db.ExtraMalzemeler.ToList());
        }
        public IActionResult Sepet(int id)
        {
            ExtraMalzeme? extra = _db.ExtraMalzemeler.Find(id);
            var menu = _db.Menuler.Find(TempData["id"]);

            decimal toplam = extra!.ExtraMalzemeFiyat + menu!.Fiyat;
            ViewBag.ToplamFiyat = toplam;
            return View();
        }
        // GET: SiparisController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SiparisController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiparisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SiparisController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SiparisController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SiparisController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SiparisController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #region Ajax
        //public IActionResult TumMenuler()
        //{
        //    var menuler = _db.Menuler;

        //    return Json(menuler);
        //}
        //public async Task<Dictionary<string, int>> Ekstralar(int id)
        //{
        //    List<string> ekstraAdlar = new();
        //    List<ExtraMalzeme> ekstralarList = new();

        //    var tumEkstralar = _db.ExtraMalzemeler;
        //    var ekstralar = await _db.Extralar
        //        .Include(x => x.ExtraMalzemelers)
        //        .Include(x => x.Menu)
        //        .Where(m => m.MenuId == id).ToListAsync();

        //    foreach (var item in ekstralar)
        //    {
        //        var ekstra = await tumEkstralar.FirstOrDefaultAsync(x => x.Id == item.EkstraId);
        //        ekstralarList.Add(ekstra);
        //    }

        //    foreach (var item in ekstralarList)
        //    {
        //        ekstraAdlar.Add(item.ExtraMalzemeAdi);
        //    }

        //    Dictionary<string, int> ekstraGrupSayisi;

        //    ekstraGrupSayisi = ekstraAdlar
        //     .GroupBy(x => x)
        //     .ToDictionary(g => g.Key, g => g.Count());

        //    return ekstraGrupSayisi;
        //}
        //public IActionResult EkstraListesi()
        //{
        //    return Json(_db.ExtraMalzemeler);
        //} 
        #endregion
    }
}
