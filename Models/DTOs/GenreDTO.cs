using System.ComponentModel.DataAnnotations;
namespace LoncotesLibrary.Models.DTOs;


public class GenreDTO
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
}