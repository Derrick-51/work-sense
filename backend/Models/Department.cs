using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Department
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public ICollection<JobType> JobTypes { get; } = new List<JobType>();

    public Department() {}

    public Department(Department department)
    {
        Id = department.Id;
        Name = department.Name;
    }

    public Department(DepartmentDTO departmentDTO)
    {
        Name = departmentDTO.Name;
    }

    // Update all non-key fields
    public void UpdateFields(Department department)
    {
        Name = department.Name;
    }
}