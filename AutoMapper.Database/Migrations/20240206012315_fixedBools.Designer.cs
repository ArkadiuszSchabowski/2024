﻿// <auto-generated />
using System;
using AutoMapper.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoMapper.Database.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240206012315_fixedBools")]
    partial class fixedBools
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoMapper.Database.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<bool?>("isPremiumAccount")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Chorzów",
                            Name = "Świnka",
                            Phone = "7806969",
                            isAdmin = true,
                            isPremiumAccount = true
                        },
                        new
                        {
                            Id = 2,
                            City = "Chorzów",
                            Name = "Paulina",
                            Phone = "500100200",
                            isAdmin = false,
                            isPremiumAccount = true
                        },
                        new
                        {
                            Id = 3,
                            City = "Chorzów",
                            Name = "Dominika",
                            Phone = "600200300",
                            isAdmin = false,
                            isPremiumAccount = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
