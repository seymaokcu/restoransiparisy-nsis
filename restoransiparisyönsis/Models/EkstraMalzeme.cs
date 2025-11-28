using System.ComponentModel.DataAnnotations;

namespace restoransiparisyönsis.Models
{
    public class EkstraMalzeme
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ekstra Malzeme")]
        public string EkstraMalzemeAd { get; set; }

        [Required]
        [Display(Name = "Ekstra Ücret")]
        public decimal EkstraMalzemeFiyat { get; set; }

    }
}