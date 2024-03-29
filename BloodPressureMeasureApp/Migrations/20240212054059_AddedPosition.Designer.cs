﻿// <auto-generated />
using System;
using BloodPressureMeasureApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BloodPressureMeasureApp.Migrations
{
    [DbContext(typeof(BloodPressureDbContext))]
    [Migration("20240212054059_AddedPosition")]
    partial class AddedPosition
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BloodPressureMeasureApp.Entities.BloodPressure", b =>
                {
                    b.Property<int>("BloodPressureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BloodPressureId"));

                    b.Property<int?>("Diastolic")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("MeasurementDate")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<string>("PositionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Systolic")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("BloodPressureId");

                    b.HasIndex("PositionId");

                    b.ToTable("BloodPressures");

                    b.HasData(
                        new
                        {
                            BloodPressureId = 1,
                            Diastolic = 121,
                            MeasurementDate = new DateTime(2008, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = "standing",
                            Systolic = 181
                        },
                        new
                        {
                            BloodPressureId = 2,
                            Diastolic = 91,
                            MeasurementDate = new DateTime(2005, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = "lying_down",
                            Systolic = 142
                        },
                        new
                        {
                            BloodPressureId = 3,
                            Diastolic = 85,
                            MeasurementDate = new DateTime(2002, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = "standing",
                            Systolic = 131
                        },
                        new
                        {
                            BloodPressureId = 4,
                            Diastolic = 79,
                            MeasurementDate = new DateTime(1998, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = "sitting",
                            Systolic = 122
                        },
                        new
                        {
                            BloodPressureId = 5,
                            Diastolic = 78,
                            MeasurementDate = new DateTime(1996, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = "sitting",
                            Systolic = 118
                        },
                        new
                        {
                            BloodPressureId = 6,
                            Diastolic = 100,
                            MeasurementDate = new DateTime(1999, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = "lying_down",
                            Systolic = 160
                        });
                });

            modelBuilder.Entity("BloodPressureMeasureApp.Entities.Position", b =>
                {
                    b.Property<string>("PositionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PositionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PositionId");

                    b.ToTable("Position", (string)null);

                    b.HasData(
                        new
                        {
                            PositionId = "standing",
                            PositionName = "Standing"
                        },
                        new
                        {
                            PositionId = "sitting",
                            PositionName = "Sitting"
                        },
                        new
                        {
                            PositionId = "lying_down",
                            PositionName = "Lying Down"
                        });
                });

            modelBuilder.Entity("BloodPressureMeasureApp.Entities.BloodPressure", b =>
                {
                    b.HasOne("BloodPressureMeasureApp.Entities.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });
#pragma warning restore 612, 618
        }
    }
}
