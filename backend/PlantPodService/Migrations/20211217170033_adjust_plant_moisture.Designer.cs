﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlantPodService.Model;

namespace PlantPodService.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211217170033_adjust_plant_moisture")]
    partial class adjust_plant_moisture
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("PlantPodService.Model.PlantEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Care")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("LongName")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MaxHumidity")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MaxTemperature")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Maxph")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MinHumidity")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MinTemperature")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Minph")
                        .HasColumnType("TEXT");

                    b.Property<int>("Moisture")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShortName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Plants");
                });
#pragma warning restore 612, 618
        }
    }
}
