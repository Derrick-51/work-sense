using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class JobTypeDTO : ITransferObject<JobType, long, JobTypeDTO>
{
    [Key]
    public long Key { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public long DepartmentKey { get; set; } = default;

    public JobTypeDTO() {}

    public JobTypeDTO(JobType jobType)
    {
        Key = jobType.Key;
        Name = jobType.Name;
        DepartmentKey = jobType.DepartmentKey;
    }

    public static implicit operator JobType(JobTypeDTO jobTypeDTO)
    {
        JobType jobType = new JobType();
        jobType.Key = jobTypeDTO.Key;
        jobType.Name = jobTypeDTO.Name;
        jobType.DepartmentKey = jobTypeDTO.DepartmentKey;
        return jobType;
    }

    public static JobTypeDTO CreateWithEntity(JobType jobType)
    {
        return new JobTypeDTO(jobType);
    }

    public void CopyFieldsTo(JobType jobType)
    {
        jobType.Key = Key;
        jobType.Name = Name;
        jobType.DepartmentKey = DepartmentKey;
    }
}