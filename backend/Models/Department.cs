using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Department
{
    
    public Department(Department department)
    {
        Id = department.Id;
        Name = department.Name;
    }
    public Department(DepartmentDTO departmentDTO)
    {
        Name = departmentDTO.Name;
    }

    [Key]
    public long Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public ICollection<JobType> JobTypes { get; } = new List<JobType>();

    public void UpdateWithDTO(DepartmentDTO departmentDTO)
    {
        Name = departmentDTO.Name;
    }
}