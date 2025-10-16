using WorkSense.Backend.Models;

namespace WorkSense.Backend.Services;

public class CampusService : CRUDService<Campus, long>
{
    public CampusService(AppDbContext dbContext)
    : base(dbContext)
    { }

    //
    // Extension methods beyond basic CRUD services
    //
}