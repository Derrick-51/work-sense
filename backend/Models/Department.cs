using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Department : BaseModel<Department, long>
{
    //
    // PROPERTIES
    //
    
    [Required]
    public string Name { get; set; } = string.Empty;

    public ICollection<JobType> JobTypes { get; } = new List<JobType>();

    //
    // CONSTRUCTORS
    //

    public Department() { }

    public Department(Department department)
    {
        Key = department.Key;
        Name = department.Name;
    }

    public Department(DepartmentDTO departmentDTO)
    {
        Name = departmentDTO.Name;
    }

    //
    // METHODS
    //

    // Update all non-key fields
    public override void UpdateFields(Department department)
    {
        Key = department.Key;
        Name = department.Name;
    }
}