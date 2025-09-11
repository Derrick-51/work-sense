using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class JobType
{
    [Key]
    public long Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public Department Department { get; set; } = null!;
}