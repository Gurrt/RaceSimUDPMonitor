﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TelemetryApi.Data.Contexts;

#nullable disable

namespace TelemetryApi.Data.Migrations
{
    [DbContext(typeof(RacesimDbContext))]
    [Migration("20250126215222_AddCurrentDriverMapping2")]
    partial class AddCurrentDriverMapping2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TelemetryApi.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.CarClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CarsClasses");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.Lap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CompletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<float>("Sector1Time")
                        .HasColumnType("real");

                    b.Property<float>("Sector2Time")
                        .HasColumnType("real");

                    b.Property<float>("Sector3Time")
                        .HasColumnType("real");

                    b.Property<int>("SessionId")
                        .HasColumnType("integer");

                    b.Property<float>("TotalTime")
                        .HasColumnType("real");

                    b.Property<bool>("Valid")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Laps");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SimulatorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TrackId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("DriverId");

                    b.HasIndex("SimulatorId");

                    b.HasIndex("TrackId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.Simulator", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int?>("CurrentDriverId")
                        .HasColumnType("integer");

                    b.Property<string>("FriendlyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("NumSessions")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CurrentDriverId");

                    b.ToTable("Simulators");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Variation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.Car", b =>
                {
                    b.HasOne("TelemetryApi.Data.Models.CarClass", "Class")
                        .WithMany("Cars")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.Lap", b =>
                {
                    b.HasOne("TelemetryApi.Data.Models.Session", "Session")
                        .WithMany("Laps")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.Session", b =>
                {
                    b.HasOne("TelemetryApi.Data.Models.Car", "Car")
                        .WithMany("Sessions")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TelemetryApi.Data.Models.Driver", "Driver")
                        .WithMany("Sessions")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TelemetryApi.Data.Models.Simulator", "Simulator")
                        .WithMany("Sessions")
                        .HasForeignKey("SimulatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TelemetryApi.Data.Models.Track", "Track")
                        .WithMany("Sessions")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Driver");

                    b.Navigation("Simulator");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.Simulator", b =>
                {
                    b.HasOne("TelemetryApi.Data.Models.Driver", "CurrentDriver")
                        .WithMany()
                        .HasForeignKey("CurrentDriverId");

                    b.Navigation("CurrentDriver");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.Car", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.CarClass", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.Driver", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.Session", b =>
                {
                    b.Navigation("Laps");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.Simulator", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("TelemetryApi.Data.Models.Track", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}