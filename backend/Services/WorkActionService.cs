using WorkSense.Backend.Models;

namespace WorkSense.Backend.Services;

public class WorkActionService : CRUDService<WorkAction, long>
{
    public WorkActionService(AppDbContext dbContext)
    : base(dbContext)
    { }

    //
    // Extension methods beyond basic CRUD services
    //
}