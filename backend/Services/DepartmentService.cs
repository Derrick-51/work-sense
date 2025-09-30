using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WorkSense.Backend.Models;
using WorkSense.Backend.Services.Results;

namespace WorkSense.Backend.Services;

public class DepartmentService
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
    public async Task<ServiceResult<Department>> GetById(long id)
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
    public async Task<ServiceResult<Department>> Post(DepartmentDTO departmentDTO)
    {
        Department newDepartment = new Department(departmentDTO);

        EntityEntry<Department> newDepartmentEntry = await DbContext.Departments.AddAsync(newDepartment);
        await DbContext.SaveChangesAsync();

        Department createdDepartment = new Department(newDepartmentEntry.Entity);

        return ServiceResult<Department>.Success(createdDepartment);
    }

    ////
    // PUT
    public async Task<ServiceResult> Put(DepartmentDTO departmentDTO)
    {
        Department? existingDepartment = await DbContext.Departments.FindAsync(departmentDTO.Id);

        if (existingDepartment is null)
        {
            return ServiceResult.Failure(ResultError.NotFound, "Department with Id: {departmentDTO.Id} not found.");
        }

        existingDepartment.UpdateWithDTO(departmentDTO);
        await DbContext.SaveChangesAsync();

        return ServiceResult.Success();
    }

    ////
    // DELETE
    public async Task<ServiceResult> Delete(long id)
    {
        await DbContext.Departments
        .Where(d => d.Id == id)
        .ExecuteDeleteAsync();

        return ServiceResult.Success();
    }
}