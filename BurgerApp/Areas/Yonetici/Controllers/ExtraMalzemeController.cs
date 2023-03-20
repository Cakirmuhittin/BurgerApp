using BurgerApp.Areas.Identity.Data;
using BurgerApp.Data;
using BurgerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BurgerApp.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    [Authorize(Roles = "admin")]
    public class ExtraMalzemeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExtraMalzemeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.ExtraMalzemeler.ToList());
        }
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Ekle(ExtraMalzemeViewModel eVm)
        {
            ExtraMalzeme extraMalzeme = new ExtraMalzeme();

            try
            {
                if (eVm.Resim != null)
                {
                    var dosyaAdi = eVm.Resim.FileName;

                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", dosyaAdi);

                    var akisOrtami = new FileStream(konum, FileMode.Create);
                    eVm.Resim.CopyTo(akisOrtami);
                    akisOrtami.Close();
                    extraMalzeme.Resim = dosyaAdi;
                }
            }
            catch (Exception ex)
            {

                TempData["DURUM"] = "Hata!" + ex.Message;
            }

            extraMalzeme.ExtraMalzemeAdi = eVm.ExtraAd;
            extraMalzeme.ExtraMalzemeFiyat = eVm.ExtraFiyat;

            _db.ExtraMalzemeler.Add(extraMalzeme);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Guncelle(int id)
        {
            ExtraMalzeme? malzeme = _db.ExtraMalzemeler.Find(id);
            if (malzeme == null) return NotFound();

            var vm = new ExtraMalzemeViewModel()
            {
                ExtraAd = malzeme.ExtraMalzemeAdi,
                ExtraFiyat = malzeme.ExtraMalzemeFiyat
            };
            TempData["id"]=id;
            return View(vm);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Guncelle(ExtraMalzemeViewModel extraVm)
        {
            if(ModelState.IsValid)
            {
                ExtraMalzeme? malzeme = _db.ExtraMalzemeler.Find(TempData["id"]);
                if(malzeme ==null) return NotFound();

                malzeme.ExtraMalzemeAdi = extraVm.ExtraAd;
                malzeme.ExtraMalzemeFiyat= extraVm.ExtraFiyat;
                if (extraVm.Resim != null)
                {
                    var dosyaAdi = extraVm.Resim.FileName;
               
                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", dosyaAdi);
                    
                    var akisOrtami = new FileStream(konum, FileMode.Create);
                  
                    extraVm.Resim.CopyTo(akisOrtami);
                    akisOrtami.Close(); 

                    malzeme.Resim = dosyaAdi;
                }
                _db.ExtraMalzemeler.Update(malzeme);
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

            var siliencekExtraMalzeme = _db.ExtraMalzemeler.Find(id);
            if (siliencekExtraMalzeme == null)
            {
                return NotFound();
            }

            return View(siliencekExtraMalzeme);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SilOnay(int? id)
        {
            var urn = _db.ExtraMalzemeler.Find(id);
            if (urn == null)
            {
                return NotFound();
            }
            _db.ExtraMalzemeler.Remove(urn);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
