namespace BurgerApp.Areas.Identity.Data
{
    public class Extra
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int EkstraId { get; set; }
        public  ExtraMalzeme ExtraMalzemelers { get; set; }
        public Menu Menu { get; set; }
    }
}
