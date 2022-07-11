using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage_2.Models;

namespace Garage_2.Data
{
    public class Garage_2Context : DbContext
    {
        public Garage_2Context (DbContextOptions<Garage_2Context> options)
            : base(options)
        {
        }

        public DbSet<Garage_2.Models.Vehicles>? Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicles>().HasData(
                new Vehicles { Id = 1, RegNo = "MDK626", VehicleType = VehicleType.Boat, Color = Color.White, Make = "Princes", Model = "Yatch", NoOfWheels = 0, PartkingStartAt = DateTime.Now },
                new Vehicles { Id = 2, RegNo = "TTT234", VehicleType = VehicleType.Car, Color = Color.Blue, Make = "Volvo", Model = "V70", NoOfWheels = 4, PartkingStartAt = DateTime.Now },
                new Vehicles { Id = 3, RegNo = "ABC334", VehicleType = VehicleType.Bus, Color = Color.Red, Make = "Volvo", Model = "240", NoOfWheels = 4,  PartkingStartAt = DateTime.Now },
                new Vehicles { Id = 4, RegNo = "ZZZ300", VehicleType = VehicleType.Bus, Color = Color.Black, Make = "Mercedes", Model = "buss", NoOfWheels = 4, PartkingStartAt = DateTime.Now },
                new Vehicles { Id = 5, RegNo = "GAG399", VehicleType = VehicleType.Car, Color = Color.Yellow, Make = "Hyunday", Model = "I20", NoOfWheels = 4 , PartkingStartAt = DateTime.Now },
                new Vehicles { Id = 6, RegNo = "YYY555", VehicleType = VehicleType.Car, Color = Color.Blue, Make = "Zusuki", Model = "Switch", NoOfWheels = 4,  PartkingStartAt = DateTime.Now }
                ); // DateTime.Parse("1997-02-25")
        }


    }
}
