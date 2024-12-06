﻿// <auto-generated />
using System;
using CivicTransportSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CivicTransportSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("CivicTransportSystem.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("CardType")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<string>("CardholderNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUsedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasDiscriminator<string>("CardType").HasValue("Card");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CivicTransportSystem.Models.CivicCard", b =>
                {
                    b.HasBaseType("CivicTransportSystem.Models.Card");

                    b.HasDiscriminator().HasValue("CivicCard");
                });

            modelBuilder.Entity("CivicTransportSystem.Models.CivicDiscountedCard", b =>
                {
                    b.HasBaseType("CivicTransportSystem.Models.Card");

                    b.Property<int>("DailyTrips")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DiscountType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("CivicDiscountedCard");
                });
#pragma warning restore 612, 618
        }
    }
}
