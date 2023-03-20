using BurgerApp.Areas.Identity.Data;
using BurgerApp.Data;
using BurgerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BurgerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger , ApplicationDbContext db)
        {
            _db= db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var resimIsimleri = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img"));
            TempData["resimler"]=resimIsimleri;
            return View();
        }     
        public IActionResult MenuEkle(int id)
        {
            YiyeceklerViewModel yWm = new()
            {
                Adet = 1,
                Menus=_db.Menuler.Find(id)!
            };
            return View(yWm);
        }
        public IActionResult Privacy()
        {
            return View();
        }
      
        public IActionResult Menuler()
        {
            List<Menu> menuListesi = _db.Menuler.ToList();
            return View(menuListesi);
        }
        public IActionResult ExtraMalzemes() 
        {
            List<ExtraMalzeme> extra = _db.ExtraMalzemeler.ToList();
            return View(extra);
        }
    
        public IActionResult Iletisim()
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