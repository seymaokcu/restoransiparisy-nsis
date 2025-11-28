using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using restoransiparisyönsis.Models; 

namespace restoransiparisyönsis.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Menu> Menuler { get; set; }
        public DbSet<EkstraMalzeme> EkstraMalzemeler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Menu>()
                .Property(m => m.MenuFiyat).HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EkstraMalzeme>()
                .Property(e => e.EkstraMalzemeFiyat).HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Siparis>()
                .Property(s => s.ToplamTutar).HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Menu>().HasData(
                new Menu { Id = 1, MenuAd = "Cheeseburger Menü", MenuFiyat = 100, ResimYolu = "cheeseburger-menu.png", Stok = 100 },
                new Menu { Id = 2, MenuAd = "BigKing Menü", MenuFiyat = 120, ResimYolu = "big-king-menu.png", Stok = 100 },
                new Menu { Id = 3, MenuAd = "King Chicken Menü", MenuFiyat = 110, ResimYolu = "king-chicken-menu.png", Stok = 100 },
                new Menu { Id = 4, MenuAd = "Karışık Izgara", MenuFiyat = 450, ResimYolu = "izgara.jpg", Stok = 50 },
                new Menu { Id = 5, MenuAd = "Adana Kebap", MenuFiyat = 320, ResimYolu = "adana.jpg", Stok = 80 },
                new Menu { Id = 6, MenuAd = "Fıstıklı Baklava", MenuFiyat = 180, ResimYolu = "baklava.jpg", Stok = 100 },
                new Menu { Id = 7, MenuAd = "Sütlaç", MenuFiyat = 90, ResimYolu = "sutlac.jpg", Stok = 50 },
                new Menu { Id = 8, MenuAd = "Yayık Ayran", MenuFiyat = 40, ResimYolu = "ayran.jpg", Stok = 200 },
                new Menu { Id = 9, MenuAd = "Cola Zero", MenuFiyat = 50, ResimYolu = "cola.jpg", Stok = 200 }
            );

            modelBuilder.Entity<EkstraMalzeme>().HasData(
                new EkstraMalzeme { Id = 1, EkstraMalzemeAd = "Ketçap", EkstraMalzemeFiyat = 2 },
                new EkstraMalzeme { Id = 2, EkstraMalzemeAd = "Mayonez", EkstraMalzemeFiyat = 2 },
                new EkstraMalzeme { Id = 3, EkstraMalzemeAd = "Ranch Sos", EkstraMalzemeFiyat = 4 }
            );
        }
    }
}