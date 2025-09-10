using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Location
{
    [Key]
    public long Id { get; set; }
    
    [Required]
    public Building Building { get; set; }
}