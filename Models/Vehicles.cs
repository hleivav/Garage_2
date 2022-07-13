using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
//https://github.com/hleivav/Garage_2

namespace Garage_2.Models
{
    public class Vehicles
    {
        public int Id { get; set; }
        [Required]
        [StringLength(6)]
        //[REMOTE]

        [Remote("CheckRegNo", "Vehicles", ErrorMessage = "Vehicle already exists")]
        public string RegNo { get; set; } = string.Empty;
        [Required]
        public VehicleType VehicleType { get; set; }
        public Color Color { get; set; }

        [StringLength(20)]
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        [Range(0, 8)]
        [Required]
        public int NoOfWheels { get; set; }
        [Required]
        public DateTime PartkingStartAt { get; set; }
        //
    }


}
