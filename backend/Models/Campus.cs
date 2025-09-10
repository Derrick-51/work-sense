using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Campus
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    public ICollection<Building> buildings { get; } = new List<Building>();
}