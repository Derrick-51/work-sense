using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Department
{
    [Key]
    public long Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;

    public ICollection<JobType> JobTypes { get; } = new List<JobType>();
}