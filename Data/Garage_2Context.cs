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

                new Vehicles { Id = 1, RegNo = "MDK626", VehicleType = VehicleType.Car, Color = Color.White, Make = "Volvo", Model = "V70", NoOfWheels = 4, PartkingStartAt = DateTime.Now},

                    new Vehicles { Id = 2, RegNo = "TTT234", VehicleType = VehicleType.Car, Color = Color.Blue, Make = "tesla", Model = "D3", NoOfWheels = 4, PartkingStartAt = DateTime.Now },

                    new Vehicles { Id = 3, RegNo = "ABC123", VehicleType = VehicleType.Car, Color = Color.Black, Make = "mercedes", Model = "C-Klass", NoOfWheels = 4, PartkingStartAt = DateTime.Now },

                    new Vehicles { Id = 4, RegNo = "DUM666", VehicleType = VehicleType.Bus, Color = Color.Yellow, Make = "Volvo", Model = "Volvobuss", NoOfWheels = 8, PartkingStartAt = DateTime.Now },

                    new Vehicles { Id = 5, RegNo = "MUU775", VehicleType = VehicleType.Boat, Color = Color.Black, Make = "Princess", Model = "Yatch", NoOfWheels = 0, PartkingStartAt = DateTime.Now },

                    new Vehicles { Id = 6, RegNo = "YUU223", VehicleType = VehicleType.Car, Color = Color.Red, Make = "Volvo", Model = "V90", NoOfWheels = 4, PartkingStartAt = DateTime.Now }


                ); ; 

        }
    }

}
