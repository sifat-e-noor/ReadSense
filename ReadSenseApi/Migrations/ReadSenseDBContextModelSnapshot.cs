﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReadSenseApi.Database;

#nullable disable

namespace ReadSenseApi.Migrations
{
    [DbContext(typeof(ReadSenseDBContext))]
    partial class ReadSenseDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReadSenseApi.Database.Entities.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DeviceInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FingerPrint")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTimeOffset?>("Inserted")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("ReadSenseApi.Database.Entities.Environment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BrightnessLevel")
                        .HasColumnType("int");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("Inserted")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("PlaceState")
                        .HasColumnType("int");

                    b.Property<int?>("TimeOfDay")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("Environments");
                });

            modelBuilder.Entity("ReadSenseApi.Database.Entities.ReadSettingsEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Align")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int>("EnvironmentId")
                        .HasColumnType("int");

                    b.Property<string>("FontSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fonts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("Inserted")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Layout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineHeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineSpacing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("TimeOfChange")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnvironmentId");

                    b.ToTable("ReadSettingsEvents");
                });

            modelBuilder.Entity("ReadSenseApi.Database.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("AgreementSigned")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset?>("Inserted")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset?>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ReadSenseApi.Database.Entities.Device", b =>
                {
                    b.HasOne("ReadSenseApi.Database.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReadSenseApi.Database.Entities.Environment", b =>
                {
                    b.HasOne("ReadSenseApi.Database.Entities.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("ReadSenseApi.Database.Entities.ReadSettingsEvent", b =>
                {
                    b.HasOne("ReadSenseApi.Database.Entities.Environment", null)
                        .WithMany("ReadSettingsEvents")
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReadSenseApi.Database.Entities.Environment", b =>
                {
                    b.Navigation("ReadSettingsEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
