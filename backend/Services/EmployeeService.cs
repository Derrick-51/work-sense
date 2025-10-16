using WorkSense.Backend.Models;

namespace WorkSense.Backend.Services;

public class EmployeeService : CRUDService<Employee, long>
{
    public EmployeeService(AppDbContext dbContext)
    : base(dbContext)
    { }

    //
    // Extension methods beyond basic CRUD services
    //
}