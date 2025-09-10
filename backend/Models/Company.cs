using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Company
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;
}