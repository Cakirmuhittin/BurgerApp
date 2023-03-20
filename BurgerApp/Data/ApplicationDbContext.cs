using BurgerApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<Kullanici>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Menu> Menuler { get; set; }
        public DbSet<ExtraMalzeme> ExtraMalzemeler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Extra> Extralar { get; set; }

    }
}