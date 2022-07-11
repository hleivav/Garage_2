﻿// <auto-generated />
using System;
using Garage_2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Garage_2.Migrations
{
    [DbContext(typeof(Garage_2Context))]
    [Migration("20220708130601_Seed")]
    partial class Seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Garage_2.Models.Vehicles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfWheels")
                        .HasColumnType("int");

                    b.Property<DateTime>("PartkingStartAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegNo")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = 4,
                            Make = "Princes",
                            Model = "Yatch",
                            NoOfWheels = 0,
                            PartkingStartAt = new DateTime(2022, 7, 8, 15, 6, 1, 216, DateTimeKind.Local).AddTicks(1297),
                            RegNo = "MDK626",
                            VehicleType = 1
                        },
                        new
                        {
                            Id = 2,
                            Color = 2,
                            Make = "Volvo",
                            Model = "V70",
                            NoOfWheels = 4,
                            PartkingStartAt = new DateTime(2022, 7, 8, 15, 6, 1, 216, DateTimeKind.Local).AddTicks(1348),
                            RegNo = "TTT234",
                            VehicleType = 0
                        },
                        new
                        {
                            Id = 3,
                            Color = 0,
                            Make = "Volvo",
                            Model = "240",
                            NoOfWheels = 4,
                            PartkingStartAt = new DateTime(2022, 7, 8, 15, 6, 1, 216, DateTimeKind.Local).AddTicks(1352),
                            RegNo = "ABC334",
                            VehicleType = 2
                        },
                        new
                        {
                            Id = 4,
                            Color = 3,
                            Make = "Mercedes",
                            Model = "buss",
                            NoOfWheels = 4,
                            PartkingStartAt = new DateTime(2022, 7, 8, 15, 6, 1, 216, DateTimeKind.Local).AddTicks(1355),
                            RegNo = "ZZZ300",
                            VehicleType = 2
                        },
                        new
                        {
                            Id = 5,
                            Color = 1,
                            Make = "Hyunday",
                            Model = "I20",
                            NoOfWheels = 4,
                            PartkingStartAt = new DateTime(2022, 7, 8, 15, 6, 1, 216, DateTimeKind.Local).AddTicks(1359),
                            RegNo = "GAG399",
                            VehicleType = 0
                        },
                        new
                        {
                            Id = 6,
                            Color = 2,
                            Make = "Zusuki",
                            Model = "Switch",
                            NoOfWheels = 4,
                            PartkingStartAt = new DateTime(2022, 7, 8, 15, 6, 1, 216, DateTimeKind.Local).AddTicks(1363),
                            RegNo = "YYY555",
                            VehicleType = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
