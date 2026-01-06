using WorkSense.Backend.Models;

namespace WorkSense.Backend.Services;

public class BuildingService : CRUDService<Building, long>
{
    public BuildingService(AppDbContext dbContext)
    : base(dbContext)
    { }

    //
    // Extension methods beyond basic CRUD services
    //
}