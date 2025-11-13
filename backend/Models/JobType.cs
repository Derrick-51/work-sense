using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class JobType : BaseModel<JobType, long>
{
    //
    // PROPERTIES
    //
    
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public Department Department { get; set; } = null!;

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
        Department = jobType.Department;
    }
}