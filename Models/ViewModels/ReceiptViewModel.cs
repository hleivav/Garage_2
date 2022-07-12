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
            public VehicleType VehicleType { get; set; }

            [Required]
            public DateTime PartkingStartAt { get; set; }
            //public DateTime ParkingEndsAt { get; set; } = DateTime.Now;
    }
}
