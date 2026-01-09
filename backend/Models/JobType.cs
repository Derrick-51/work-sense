using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSense.Backend.Models;

public class JobType : BaseModel<JobType, long>
{
    //
    // PROPERTIES
    //
    
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [ForeignKey(nameof(Department))]
    public long DepartmentKey { get; set; } = default;
    public Department? Department { get; set; }

    //
    // CONSTRUCTORS
    //

    public JobType() {}

    public JobType(JobType jobType)
    {
        UpdateFieldsUsing(jobType);
    }

    //
    // METHODS
    //

    public override void UpdateFieldsUsing(JobType jobType)
    {
        Key = jobType.Key;
        Name = jobType.Name;
        DepartmentKey = jobType.DepartmentKey;
        Department = jobType.Department;
    }
}