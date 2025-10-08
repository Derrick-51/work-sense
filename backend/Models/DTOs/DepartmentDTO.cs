using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class DepartmentDTO
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public DepartmentDTO(Department department)
    {
        Id = department.Id;
        Name = department.Name;
    }
    
    public static implicit operator Department(DepartmentDTO dto)
    {
        Department department = new Department();
        department.Id = dto.Id;
        department.Name = dto.Name;
        return department;
    }
}