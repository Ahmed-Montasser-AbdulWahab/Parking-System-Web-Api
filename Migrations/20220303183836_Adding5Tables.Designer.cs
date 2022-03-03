﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parking_System_API.Data.DBContext;

namespace Parking_System_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220303183836_Adding5Tables")]
    partial class Adding5Tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Parking_System_API.Data.Entities.Hardware", b =>
                {
                    b.Property<int>("HardwareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConnectionString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Direction")
                        .HasColumnType("bit");

                    b.Property<int>("HardwareType")
                        .HasColumnType("int");

                    b.Property<bool>("Service")
                        .HasColumnType("bit");

                    b.HasKey("HardwareId");

                    b.ToTable("Hardware");
                });

            modelBuilder.Entity("Parking_System_API.Data.Entities.ParkingTransaction", b =>
                {
                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<string>("PlateNumberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("HardwareId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeTransaction")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Result")
                        .HasColumnType("bit");

                    b.HasKey("ParticipantId", "PlateNumberId", "HardwareId", "DateTimeTransaction");

                    b.HasIndex("HardwareId");

                    b.HasIndex("PlateNumberId");

                    b.ToTable("ParkingTransactions");
                });

            modelBuilder.Entity("Parking_System_API.Data.Entities.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DoDetected")
                        .HasColumnType("bit");

                    b.Property<bool>("DoProvidePhoto")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ParticipantId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Parking_System_API.Data.Entities.SystemUser", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Type")
                        .HasColumnType("bit");

                    b.HasKey("Email");

                    b.ToTable("SystemUsers");
                });

            modelBuilder.Entity("Parking_System_API.Data.Entities.Vehicle", b =>
                {
                    b.Property<string>("PlateNumberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndSubscription")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPresent")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartSubscription")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubCategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlateNumberId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("ParticipantVehicle", b =>
                {
                    b.Property<int>("ParticipantsParticipantId")
                        .HasColumnType("int");

                    b.Property<string>("VehiclesPlateNumberId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ParticipantsParticipantId", "VehiclesPlateNumberId");

                    b.HasIndex("VehiclesPlateNumberId");

                    b.ToTable("Participant_Vehicle");
                });

            modelBuilder.Entity("Parking_System_API.Data.Entities.ParkingTransaction", b =>
                {
                    b.HasOne("Parking_System_API.Data.Entities.Hardware", "hardware")
                        .WithMany("ParkingTransactions")
                        .HasForeignKey("HardwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Parking_System_API.Data.Entities.Participant", "participant")
                        .WithMany("ParkingTransactions")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Parking_System_API.Data.Entities.Vehicle", "vehicle")
                        .WithMany("ParkingTransactions")
                        .HasForeignKey("PlateNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hardware");

                    b.Navigation("participant");

                    b.Navigation("vehicle");
                });

            modelBuilder.Entity("ParticipantVehicle", b =>
                {
                    b.HasOne("Parking_System_API.Data.Entities.Participant", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Parking_System_API.Data.Entities.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesPlateNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Parking_System_API.Data.Entities.Hardware", b =>
                {
                    b.Navigation("ParkingTransactions");
                });

            modelBuilder.Entity("Parking_System_API.Data.Entities.Participant", b =>
                {
                    b.Navigation("ParkingTransactions");
                });

            modelBuilder.Entity("Parking_System_API.Data.Entities.Vehicle", b =>
                {
                    b.Navigation("ParkingTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
