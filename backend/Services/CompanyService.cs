using WorkSense.Backend.Models;

namespace WorkSense.Backend.Services;

public class CompanyService : CRUDService<Company, long>
{
    public CompanyService(AppDbContext dbContext)
    : base(dbContext)
    { }

    //
    // Extension methods beyond basic CRUD services
    //
}