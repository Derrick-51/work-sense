using WorkSense.Backend.Models;

namespace WorkSense.Backend.Services;

public class LocationService : CRUDService<Location, long>
{
    public LocationService(AppDbContext dbContext)
    : base(dbContext)
    { }

    //
    // Extension methods beyond basic CRUD services
    //
}