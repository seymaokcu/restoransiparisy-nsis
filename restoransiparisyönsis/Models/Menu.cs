using System.ComponentModel.DataAnnotations; 

namespace restoransiparisyönsis.Models 
{
    public class Menu
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Menü adı boş bırakılamaz.")]
        [Display(Name = "Menü Adı")]
        public string MenuAd { get; set; }

        [Required(ErrorMessage = "Fiyat bilgisi gereklidir.")]
        [Display(Name = "Fiyat")]
        public decimal MenuFiyat { get; set; }

        [Display(Name = "Menü Görseli")]
        public string? ResimYolu { get; set; } 

        [Display(Name = "Stok Adedi")]
        public int Stok { get; set; } 
        public virtual ICollection<Siparis>? Siparisler { get; set; }
    }
}
