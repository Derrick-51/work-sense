using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WorkSense.Backend.Models;
using WorkSense.Backend.Services.Results;

namespace WorkSense.Backend.Services;

public class DepartmentService : ICRUDService<Department, long>
{
    private readonly AppDbContext DbContext;

    public DepartmentService(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    ////
    // GET ALL
    public async Task<ServiceResult<List<Department>>> GetAll()
    {
        List<Department> departments = await DbContext.Departments.ToListAsync();

        if (departments.Count == 0)
        {
            return ServiceResult<List<Department>>.Failure(ResultError.NotFound, "No departments found");
        }

        return ServiceResult<List<Department>>.Success(departments);
    }

    ////
    // GET BY ID
    public async Task<ServiceResult<Department>> GetByKey(long id)
    {
        Department? department = await DbContext.Departments.FindAsync(id);

        if (department is null)
        {
            return ServiceResult<Department>.Failure(ResultError.NotFound, $"Department with id: {id} not found");
        }

        return ServiceResult<Department>.Success(department);
    }

    ////
    // POST
    public async Task<ServiceResult<Department>> Post(Department department)
    {
        Department newDepartment = new Department(department);

        EntityEntry<Department> newDepartmentEntry = await DbContext.Departments.AddAsync(newDepartment);
        await DbContext.SaveChangesAsync();

        Department createdDepartment = new Department(newDepartmentEntry.Entity);

        return ServiceResult<Department>.Success(createdDepartment);
    }

    ////
    // PUT
    public async Task<ServiceResult<Department>> Put(Department department)
    {
        Department? existingDepartment = await DbContext.Departments.FindAsync(department.Id);

        if (existingDepartment is null)
        {
            return ServiceResult<Department>.Failure(ResultError.NotFound, "Department with Id: {departmentDTO.Id} not found.");
        }

        existingDepartment.UpdateFields(department);
        await DbContext.SaveChangesAsync();

        return ServiceResult<Department>.Success(existingDepartment);
    }

    ////
    // DELETE
    public async Task<IServiceResult> Delete(long id)
    {
        await DbContext.Departments
        .Where(d => d.Id == id)
        .ExecuteDeleteAsync();

        return ServiceResult.Success();
    }
}