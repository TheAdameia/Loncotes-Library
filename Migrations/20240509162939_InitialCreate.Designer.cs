﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Loncotes_Library.Migrations
{
    [DbContext(typeof(LoncotesLibraryDbContext))]
    [Migration("20240509162939_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LoncotesLibrary.Models.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckoutDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MaterialId")
                        .HasColumnType("integer");

                    b.Property<int>("PatronId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Checkouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheckoutDate = new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 1,
                            PatronId = 1
                        });
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Scifi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Nonfiction"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Self-help"
                        },
                        new
                        {
                            Id = 5,
                            Name = "History"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Educational"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Classics"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Fiction"
                        });
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MaterialTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("OutOfCirculationSince")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 8,
                            MaterialName = "The Count of Monte Cristo",
                            MaterialTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 5,
                            MaterialName = "Born in Blood and Fire",
                            MaterialTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 7,
                            MaterialName = "The Awakening",
                            MaterialTypeId = 1
                        },
                        new
                        {
                            Id = 4,
                            GenreId = 2,
                            MaterialName = "Project: Hail Mary",
                            MaterialTypeId = 4
                        },
                        new
                        {
                            Id = 5,
                            GenreId = 4,
                            MaterialName = "Windows 98 Mixtape",
                            MaterialTypeId = 3
                        },
                        new
                        {
                            Id = 6,
                            GenreId = 7,
                            MaterialName = "King James Bible",
                            MaterialTypeId = 1
                        },
                        new
                        {
                            Id = 7,
                            GenreId = 3,
                            MaterialName = "The Economist, February 2022",
                            MaterialTypeId = 2
                        },
                        new
                        {
                            Id = 8,
                            GenreId = 1,
                            MaterialName = "Gideon the Ninth",
                            MaterialTypeId = 4
                        },
                        new
                        {
                            Id = 9,
                            GenreId = 4,
                            MaterialName = "Diss track",
                            MaterialTypeId = 3
                        },
                        new
                        {
                            Id = 10,
                            GenreId = 3,
                            MaterialName = "Introduction to Buddhism",
                            MaterialTypeId = 1
                        });
                });

            modelBuilder.Entity("LoncotesLibrary.Models.MaterialType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CheckoutDays")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MaterialTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheckoutDays = 14,
                            Name = "Book"
                        },
                        new
                        {
                            Id = 2,
                            CheckoutDays = 10,
                            Name = "Periodical"
                        },
                        new
                        {
                            Id = 3,
                            CheckoutDays = 7,
                            Name = "CD"
                        },
                        new
                        {
                            Id = 4,
                            CheckoutDays = 14,
                            Name = "Ebook"
                        });
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Patron", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patrons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "1600 Lurker St",
                            Email = "LurkinAnSmirkin@gmail.com",
                            FirstName = "A. D.",
                            IsActive = true,
                            LastName = "Lurker"
                        },
                        new
                        {
                            Id = 2,
                            Address = "High St Rd",
                            Email = "FancyPrancy@gmail.com",
                            FirstName = "Ms.",
                            IsActive = true,
                            LastName = "Eliot"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Stone Paved Rd",
                            Email = "dickens@gmail.com",
                            FirstName = "Artful",
                            IsActive = false,
                            LastName = "Dodger"
                        },
                        new
                        {
                            Id = 4,
                            Address = "1st Hugo St",
                            Email = "starswithoutcounting@gmail.com",
                            FirstName = "Monsigneur",
                            IsActive = true,
                            LastName = "Javier"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}