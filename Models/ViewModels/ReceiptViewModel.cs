using System;
using System.ComponentModel.DataAnnotations;

namespace Garage_2.Models.ViewModels
{
    public class ReceiptViewModel
    {
            public int Id { get; set; }

            [Required]
            [StringLength(6)]
            public string RegNo { get; set; } = string.Empty;
            [Required]
            public DateTime PartkingStartAt { get; set; }
            public int CostForHour { get; set; } = 40;
       // [DisplayFormat()]
            public TimeSpan ParkedTime { get; set; }
       
        [Display(Name ="Total kostnad")]
        public double TotalCost { get;  set; }
        //public DateTime TimeElapsed { get; set; } = DateTime.Now;
    }
}
