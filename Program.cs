using LoncotesLibrary.Models;
using LoncotesLibrary.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<LoncotesLibraryDbContext>(builder.Configuration["LoncotesLibraryDbConnectionString"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/materials", (LoncotesLibraryDbContext db, int? GenreInput, int? MaterialTypeInput) =>
{
    return db.Materials
    .Include(m => m.Genre)
    .Include(m => m.MaterialType)
    .Where(m => m.OutOfCirculationSince == null &&
                    (MaterialTypeInput == null || m.MaterialTypeId == MaterialTypeInput) &&
                    (GenreInput == null || m.GenreId == GenreInput))
    .Select(m => new MaterialDTO
    {
        Id = m.Id,
        MaterialName = m.MaterialName,
        MaterialTypeId = m.MaterialTypeId,
        MaterialType = new MaterialTypeDTO
        {
            Id = m.MaterialType.Id,
            Name = m.MaterialType.Name,
            CheckoutDays = m.MaterialType.CheckoutDays
        },
        GenreId = m.GenreId,
        Genre = new GenreDTO
        {
            Id = m.Genre.Id,
            Name = m.Genre.Name
        }
    }).ToList();
});

// this was a good first attempt but it was not correct
// app.MapGet("/api/materials/{id}", (LoncotesLibraryDbContext db, int id) =>
// {
//     // instead of "joining" checkouts, I could create a new list for them here and then first-search it for the right one.

//     List<CheckoutDTO> checkoutList = db.Checkouts.Select(c => new CheckoutDTO
//     {
//         Id = c.Id,
//         MaterialId = c.MaterialId,
//         PatronId = c.PatronId,
//         CheckoutDate = c.CheckoutDate
//     }).ToList();

//     List<CheckoutDTO> correctCheckouts = checkoutList.Where(c => c.MaterialId == id).ToList();

//     return db.Materials
//     .Include(m => m.Genre)
//     .Include(m => m.MaterialType)
//     .Select(m => new MaterialDTO
//     {
//         Id = m.Id,
//         MaterialName = m.MaterialName,
//         MaterialTypeId = m.MaterialTypeId,
//         MaterialType =  new MaterialTypeDTO
//         {
//             Id = m.MaterialType.Id,
//             Name = m.MaterialType.Name,
//             CheckoutDays = m.MaterialType.CheckoutDays
//         },
//         GenreId = m.GenreId,
//         Genre = new GenreDTO
//         {
//             Id = m.Genre.Id,
//             Name = m.Genre.Name
//         },
//         Checkouts = correctCheckouts.Select(c => new CheckoutDTO
//         {
//             Id = c.Id,
//             MaterialId = c.MaterialId,
//             PatronId = c.PatronId,
//             CheckoutDate = c.CheckoutDate
//         }).ToList()
//     });

// });

app.MapGet("/api/materials/{id}", (LoncotesLibraryDbContext db, int id) =>
{
    return db.Materials
    .Include(m => m.Genre)
    .Include(m => m.MaterialType)
    .Include(m => m.Checkouts)
        .ThenInclude(co => co.Patron)
    .Select(m => new MaterialDTO
    {
        Id = m.Id,
        MaterialName = m.MaterialName,
        MaterialTypeId = m.MaterialTypeId,
        MaterialType =  new MaterialTypeDTO
        {
            Id = m.MaterialType.Id,
            Name = m.MaterialType.Name,
            CheckoutDays = m.MaterialType.CheckoutDays
        },
        GenreId = m.GenreId,
        Genre = new GenreDTO
        {
            Id = m.Genre.Id,
            Name = m.Genre.Name
        }
    });

});

app.MapPost("/api/materials", (LoncotesLibraryDbContext db, Material material) =>
{
    db.Materials.Add(material);
    db.SaveChanges();
    return Results.Created($"/api/materials/{material.Id}", material);
});

app.MapDelete("/api/materials/{id}", (LoncotesLibraryDbContext db, int id) =>
{
    Material material = db.Materials.SingleOrDefault(m => m.Id == id);
    if (material == null)
    {
        return Results.NotFound();
    }
    material.OutOfCirculationSince = DateTime.Now;
    db.SaveChanges();
    return Results.NoContent();
});

app.MapGet("/api/materialTypes", (LoncotesLibraryDbContext db) =>
{
    return db.MaterialTypes
    .Select(m => new MaterialTypeDTO
    {
        Id = m.Id,
        Name = m.Name,
        CheckoutDays = m.CheckoutDays
    });
});

app.Run();

