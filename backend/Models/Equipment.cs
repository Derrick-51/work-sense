using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Equipment
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Manufacturer { get; set; } = string.Empty;

    [Required]
    public string Serial { get; set; }

    public DateOnly InstallDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Required]
    public Location Location { get; set; }
}