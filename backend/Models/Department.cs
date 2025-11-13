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
        UpdateFieldsUsing(department);
    }

    //
    // METHODS
    //

    public override void UpdateFieldsUsing(Department department)
    {
        Key = department.Key;
        Name = department.Name;
    }
}