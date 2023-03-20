namespace BurgerApp.Models
{
    public class MenuViewModel
    {
        public string MenuAd { get; set; }

        public decimal MenuFiyat { get; set; }

        public IFormFile? Resim { get; set; }
    }
}
