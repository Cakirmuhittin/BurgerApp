namespace BurgerApp.Areas.Identity.Data
{
    public class Menu
    {
        public int Id { get; set; }
        public string MenuAdi { get; set; } = null!;
        public decimal Fiyat { get; set; }
        public string? Resim { get; set;}
        public List<ExtraMalzeme> ExtraMalzemeList { get;set; }
        public List<Siparis> Siparisler { get; set; }
    }
}
