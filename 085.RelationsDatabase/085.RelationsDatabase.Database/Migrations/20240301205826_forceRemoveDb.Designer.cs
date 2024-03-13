﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _085.RelationsDatabase.Database;

#nullable disable

namespace _085.RelationsDatabase.Database.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240301205826_forceRemoveDb")]
    partial class forceRemoveDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_085.RelationsDatabase.Database.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Kraków",
                            Country = "Polska",
                            Street = "Nowa",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            City = "Poznań",
                            Country = "Polska",
                            Street = "Stara",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("_085.RelationsDatabase.Database.Entities.AllegroUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nick")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AllegroUsers");
                });

            modelBuilder.Entity("_085.RelationsDatabase.Database.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("_085.RelationsDatabase.Database.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "abc@o2.pl",
                            Name = "Arek",
                            Phone = "700-600-500"
                        },
                        new
                        {
                            Id = 2,
                            Email = "cdf@o2.pl",
                            Name = "Damian",
                            Phone = "100-600-100"
                        });
                });

            modelBuilder.Entity("_085.RelationsDatabase.Database.Entities.Address", b =>
                {
                    b.HasOne("_085.RelationsDatabase.Database.Entities.User", "User")
                        .WithOne("Adress")
                        .HasForeignKey("_085.RelationsDatabase.Database.Entities.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("_085.RelationsDatabase.Database.Entities.Comment", b =>
                {
                    b.HasOne("_085.RelationsDatabase.Database.Entities.AllegroUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("_085.RelationsDatabase.Database.Entities.AllegroUser", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("_085.RelationsDatabase.Database.Entities.User", b =>
                {
                    b.Navigation("Adress")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}