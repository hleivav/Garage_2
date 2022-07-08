using System.ComponentModel.DataAnnotations;

namespace Garage_2.Models
{
    public class Vehicles
    {   
        public string id { get; set; }

        [Required]
        [StringLength(6)]
        public string Regno { get; set; } = string.Empty;

        [Required]
        public VehicleType VehicleType { get; set;}
        public Color color { get; set; }

        [StringLength(20)]
        
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        [Range(0,8)]
        public int NoOfWheels { get; set; }
        public DateTime ParkingStartAt { get; set; }    

    }


}
