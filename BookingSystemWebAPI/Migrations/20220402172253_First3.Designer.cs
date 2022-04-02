﻿// <auto-generated />
using System;
using BookingSystemWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingSystemWebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220402172253_First3")]
    partial class First3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookingSystemWebAPI.Models.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookingTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingTypeId");

                    b.HasIndex("FacilityId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BookingSystemWebAPI.Models.Entities.BookingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("TimeInMinutes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.ToTable("BookingTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FacilityId = 1,
                            Name = "Klippning kort hår",
                            Price = 100,
                            TimeInMinutes = 30
                        },
                        new
                        {
                            Id = 2,
                            FacilityId = 1,
                            Name = "Klippning långt hår",
                            Price = 200,
                            TimeInMinutes = 60
                        });
                });

            modelBuilder.Entity("BookingSystemWebAPI.Models.Entities.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Facilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Storgatan 1",
                            Name = "HairÄrVi"
                        });
                });

            modelBuilder.Entity("BookingSystemWebAPI.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookingSystemWebAPI.Models.Entities.Booking", b =>
                {
                    b.HasOne("BookingSystemWebAPI.Models.Entities.BookingType", "BookingType")
                        .WithMany()
                        .HasForeignKey("BookingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingSystemWebAPI.Models.Entities.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BookingSystemWebAPI.Models.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("BookingType");

                    b.Navigation("Facility");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingSystemWebAPI.Models.Entities.BookingType", b =>
                {
                    b.HasOne("BookingSystemWebAPI.Models.Entities.Facility", "Facility")
                        .WithMany("BookingTypes")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("BookingSystemWebAPI.Models.Entities.Facility", b =>
                {
                    b.Navigation("BookingTypes");
                });

            modelBuilder.Entity("BookingSystemWebAPI.Models.Entities.User", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
