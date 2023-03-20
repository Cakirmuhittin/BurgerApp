namespace BurgerApp.Areas.Identity.Data
{
    public class Siparis
    {
        public int Id { get; set; }
        public Menu SeciliMenu { get; set; }
        public List<ExtraMalzeme> ExtraMalzeme { get; set; }
        public BoyutEnum Boyutu { get; set; }
        public int Adet { get; set; }
        public decimal ToplamTutar { get; set; }

        
       
       
    }
}
