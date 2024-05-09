using System.ComponentModel.DataAnnotations;
namespace LoncotesLibrary.Models;

public class Material
{
    public int Id { get; set; }
    [Required]
    public string MaterialName { get; set; }
    [Required]
    public int MaterialTypeId { get; set; }
    [Required]
    public int GenreId { get; set; }
    public DateTime? OutOfCirculationSince { get; set; }
}