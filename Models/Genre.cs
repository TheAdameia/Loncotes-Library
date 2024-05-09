using System.ComponentModel.DataAnnotations;
namespace LocontesLibrary.Models;

public class Genre
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
}