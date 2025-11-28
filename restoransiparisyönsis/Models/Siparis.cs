using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace restoransiparisyönsis.Models
{
    public class Siparis
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Sipariş Tarihi")]
        public DateTime SiparisTarihi { get; set; } = DateTime.Now; 

        [Required]
        [Display(Name = "Adet")]
        public int Adet { get; set; }

        [Display(Name = "Toplam Tutar")]
        public decimal ToplamTutar { get; set; }

        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }

        public string UserId { get; set; }
    }
}
