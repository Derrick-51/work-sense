using Microsoft.EntityFrameworkCore;
using WorkSense.Backend.Models;
using WorkSense.Backend.Services.Results;

namespace WorkSense.Backend.Services;

public class EmployeeService : CRUDService<Employee, long>
{
    public EmployeeService(AppDbContext dbContext)
    : base(dbContext)
    { }

    //
    // Extension methods beyond basic CRUD services
    //

    async override public Task<ServiceResult<Employee>> Post(Employee employee)
    {
        // Verify foreign entities exist
        if (!await DbContext.Campuses.AnyAsync(c => c.Key == employee.CampusKey))
            return ServiceResult<Employee>
            .Failure(ResultError.BadRequest,
            $"Campus with key: {employee.CampusKey} does not exist");
        if (!await DbContext.Departments.AnyAsync(d => d.Key == employee.DepartmentKey))
            return ServiceResult<Employee>
            .Failure(ResultError.BadRequest,
            $"Department with key: {employee.DepartmentKey} does not exist");

        return await base.Post(employee);
    }
}