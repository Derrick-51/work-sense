using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Building
{
    [Key]
    public long Id { get; set; }

    [Required]
    public Campus Campus { get; set; } = null!;

    public ICollection<Location> locations { get; } = new List<Location>();
}