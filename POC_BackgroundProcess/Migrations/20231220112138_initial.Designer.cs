﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POC_BackGroundProcess.Database.Data;

#nullable disable

namespace POC_BackgroundProcess.Migrations
{
    [DbContext(typeof(BackgroundProcessDbContext))]
    [Migration("20231220112138_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("POC_BackGroundProcess.Database.Model.BrowserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BrowserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BrowserInfo", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
