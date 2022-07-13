using System;
using System.ComponentModel.DataAnnotations;

namespace Garage_2.Models.ViewModels
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Registreringsnummer")]
        public string RegNo { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Parkeringen startades")]
        public DateTime PartkingStartAt { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "Pris per timme")]
        public float CostForHour { get; set; } = 40;
        [Display(Name = "Parkerad tid i timmar")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:t}")]

        public TimeSpan ParkedTime { get; set; }
       
        [Display(Name ="Total kostnad")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double TotalCost { get;  set; }
    }
}
