namespace BurgerApp.Areas.Identity.Data
{
    public class ExtraMalzeme
    {
        public int Id { get; set; }
        public string ExtraMalzemeAdi { get; set; } = null!;
        public decimal ExtraMalzemeFiyat { get; set; }
        public string? Resim { get; set; }
        public List<Siparis> Siparisler { get; set; } = new();
        public List<Extra> Extralar { get; set; } = new();
    }
}
