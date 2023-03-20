using BurgerApp.Data;
using BurgerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    [Authorize(Roles = "admin")]
    public class ListeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ListeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var extra = _db.ExtraMalzemeler.ToList();
            var menu = _db.Menuler.ToList();
            var yeni = new IkiliViewModel()
            {
                Extralar = extra,
                Menuler = menu,
            };
            return View(yeni);
        }
    }
}
