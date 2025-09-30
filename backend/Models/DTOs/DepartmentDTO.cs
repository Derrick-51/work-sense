using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class DepartmentDTO
{
    public DepartmentDTO(Department department)
    {
        Id = department.Id;
        Name = department.Name;
    }

    [Key]
    public long Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
}