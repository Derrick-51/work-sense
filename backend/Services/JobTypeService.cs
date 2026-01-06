using WorkSense.Backend.Models;

namespace WorkSense.Backend.Services;

public class JobTypeService : CRUDService<JobType, long>
{
    public JobTypeService(AppDbContext dbContext)
    : base(dbContext)
    { }

    //
    // Extension methods beyond basic CRUD services
    //
}