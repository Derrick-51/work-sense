using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class JobType
{
    [Key]
    [Required]
    public string Name { get; set; }
    public Department Department { get; set; }
}