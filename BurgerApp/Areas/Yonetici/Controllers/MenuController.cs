using BurgerApp.Areas.Identity.Data;
using BurgerApp.Data;
using BurgerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    [Authorize(Roles ="admin")]
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MenuController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Menuler.ToList());
        }
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Ekle(MenuViewModel menuVm)
        {
            Menu menu = new Menu();
            try
            {
                if (menuVm.Resim != null)
                {
                    var dosyaAdi = menuVm.Resim.FileName;
                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", dosyaAdi);

                    var akisOrtami = new FileStream(konum, FileMode.Create);
                    menuVm.Resim.CopyTo(akisOrtami);
                    akisOrtami.Close();
                    menu.Resim = dosyaAdi;
                }
            }
            catch (Exception ex)
            {

                TempData["durum"] = "Hata!"+ex.Message;
            }

            menu.MenuAdi = menuVm.MenuAd;
            menu.Fiyat = menuVm.MenuFiyat;
            _db.Menuler.Add(menu);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Guncelle(int id)
        {
            Menu? menu = _db.Menuler.Find(id);
            if (menu == null) return NotFound();

            var vm = new MenuViewModel()
            {
                MenuAd = menu.MenuAdi,
                MenuFiyat = menu.Fiyat
            };
            TempData["id"] = id;
            return View(vm);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Guncelle(MenuViewModel menuVm)
        {
            if (ModelState.IsValid)
            {
                Menu? menu = _db.Menuler.Find(TempData["id"]);
                if (menu == null) return NotFound();

                menu.MenuAdi = menuVm.MenuAd;
                menu.Fiyat = menuVm.MenuFiyat;
                if (menuVm.Resim != null)
                {
                    var dosyaAdi = menuVm.Resim.FileName;

                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", dosyaAdi);

                    var akisOrtami = new FileStream(konum, FileMode.Create);

                    menuVm.Resim.CopyTo(akisOrtami);
                    akisOrtami.Close();

                    menu.Resim = dosyaAdi;
                }
                _db.Menuler.Update(menu);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var siliencekMenu = _db.Menuler.Find(id);
            if (siliencekMenu == null)
            {
                return NotFound();
            }

            return View(siliencekMenu);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Sil")]
        public IActionResult SilOnay(int? id)
        {
            var obj = _db.Menuler.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Menuler.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("index");

        }
    }
}
