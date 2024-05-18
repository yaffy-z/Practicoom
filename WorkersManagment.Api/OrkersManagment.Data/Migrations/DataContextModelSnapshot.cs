﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkersManagment.Data;

#nullable disable

namespace WorkersManagment.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WorkersManagment.Core.Models.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PositionId"));

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PositionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("WorkersManagment.Core.Models.PositionWorker", b =>
                {
                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsManagement")
                        .HasColumnType("bit");

                    b.Property<bool>("StatusActive")
                        .HasColumnType("bit");

                    b.HasKey("WorkerId", "PositionId");

                    b.HasIndex("PositionId");

                    b.ToTable("PositionsWorker");
                });

            modelBuilder.Entity("WorkersManagment.Core.Models.Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkerId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Identity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StatusActive")
                        .HasColumnType("bit");

                    b.HasKey("WorkerId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("WorkersManagment.Core.Models.PositionWorker", b =>
                {
                    b.HasOne("WorkersManagment.Core.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkersManagment.Core.Models.Worker", "Employee")
                        .WithMany("PositionWorkers")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("WorkersManagment.Core.Models.Worker", b =>
                {
                    b.Navigation("PositionWorkers");
                });
#pragma warning restore 612, 618
        }
    }
}
