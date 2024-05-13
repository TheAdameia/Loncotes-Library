using Microsoft.EntityFrameworkCore;
using LoncotesLibrary.Models;

public class LoncotesLibraryDbContext : DbContext
{

    public DbSet<Checkout> Checkouts { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<MaterialType> MaterialTypes { get; set; }
    public DbSet<Patron> Patrons { get; set; }

    public LoncotesLibraryDbContext(DbContextOptions<LoncotesLibraryDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Checkout>().HasData(new Checkout[]
        {
            new Checkout {Id = 1, MaterialId = 1, PatronId = 1, CheckoutDate = new (2024, 5, 8)},
        });

        modelBuilder.Entity<Genre>().HasData(new Genre[]
        {
            new Genre {Id = 1, Name = "Fantasy"},
            new Genre {Id = 2, Name = "Scifi"},
            new Genre {Id = 3, Name = "Nonfiction"},
            new Genre {Id = 4, Name = "Self-help"},
            new Genre {Id = 5, Name = "History"},
            new Genre {Id = 6, Name = "Educational"},
            new Genre {Id = 7, Name = "Classics"},
            new Genre {Id = 8, Name = "Fiction"}
        });

        modelBuilder.Entity<Patron>().HasData(new Patron[]
        {
            new Patron {Id = 1, FirstName = "A. D.", LastName = "Lurker", Address = "1600 Lurker St", Email = "LurkinAnSmirkin@gmail.com", IsActive = true},
            new Patron {Id = 2, FirstName = "Ms.", LastName = "Eliot", Address = "High St Rd", Email = "FancyPrancy@gmail.com", IsActive = true},
            new Patron {Id = 3, FirstName = "Artful", LastName = "Dodger", Address = "Stone Paved Rd", Email = "dickens@gmail.com", IsActive = false},
            new Patron {Id = 4, FirstName = "Monsigneur", LastName = "Javier", Address = "1st Hugo St", Email = "starswithoutcounting@gmail.com", IsActive = true}
        });

        modelBuilder.Entity<Material>().HasData(new Material[]
        {
            new Material {Id = 1, MaterialName = "The Count of Monte Cristo", MaterialTypeId = 1, GenreId = 8},
            new Material {Id = 2, MaterialName = "Born in Blood and Fire", MaterialTypeId = 1, GenreId = 5},
            new Material {Id = 3, MaterialName = "The Awakening", MaterialTypeId = 1, GenreId = 7},
            new Material {Id = 4, MaterialName = "Project: Hail Mary", MaterialTypeId = 4, GenreId = 2},
            new Material {Id = 5, MaterialName = "Windows 98 Mixtape", MaterialTypeId = 3, GenreId = 4},
            new Material {Id = 6, MaterialName = "King James Bible", MaterialTypeId = 1, GenreId = 7},
            new Material {Id = 7, MaterialName = "The Economist, February 2022", MaterialTypeId = 2, GenreId = 3},
            new Material {Id = 8, MaterialName = "Gideon the Ninth", MaterialTypeId = 4, GenreId = 1},
            new Material {Id = 9, MaterialName = "Diss track", MaterialTypeId = 3, GenreId = 4},
            new Material {Id = 10, MaterialName = "Introduction to Buddhism", MaterialTypeId = 1, GenreId = 3}
        });

        modelBuilder.Entity<MaterialType>().HasData(new MaterialType[]
        {
            new MaterialType {Id = 1, Name = "Book", CheckoutDays = 14},
            new MaterialType {Id = 2, Name = "Periodical", CheckoutDays = 10},
            new MaterialType {Id = 3, Name = "CD", CheckoutDays = 7},
            new MaterialType {Id = 4, Name = "Ebook", CheckoutDays = 14}
        });
    }
}