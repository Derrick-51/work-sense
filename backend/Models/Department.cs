using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Department
{
    [Key]
    [Required]
    public string Name { get; set; }

    public ICollection<JobType> JobTypes { get; } = new List<JobType>();
}