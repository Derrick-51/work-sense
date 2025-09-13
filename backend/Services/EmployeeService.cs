using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services.Results;

namespace WorkSense.Backend.Services;

public interface IEmployeeService
{
    public Task<ServiceResult<List<Employee>>> GetAll();
    public Task<ServiceResult<Employee>> GetById(long id);
    public Task<ServiceResult<Employee>> Add(EmployeeDTO employeeDTO);
    public Task<ServiceResult<Employee>> Update(EmployeeDTO employeeDTO);
    public Task<ServiceResult> Delete(long id);
}

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext DbContext;

    public EmployeeService(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    ////
    // GET ALL
    public async Task<ServiceResult<List<Employee>>> GetAll()
    {
        List<Employee> employees = await DbContext.Employees.ToListAsync();

        if (employees.Count == 0)
        {
            return ServiceResult<List<Employee>>.Failure(ResultError.NotFound, "No Employees found.");
        }

        return ServiceResult<List<Employee>>.Success(employees);
    }

    ////
    // GET ONE (ID)
    public async Task<ServiceResult<Employee>> GetById(long id)
    {
        Employee? foundEmployee = await DbContext.Employees.FindAsync(id);

        if (foundEmployee == null)
        {
            return ServiceResult<Employee>.Failure(ResultError.NotFound, "Employee not found.");
        }
        return ServiceResult<Employee>.Success(foundEmployee);
    }

    ////
    // ADD
    public async Task<ServiceResult<Employee>> Add(EmployeeDTO employeeDTO)
    {
        Employee newEmployee = new Employee();
        newEmployee.UpdateWithDTO(employeeDTO);

        DbContext.Employees.Add(newEmployee);
        await DbContext.SaveChangesAsync();

        return ServiceResult<Employee>.Success(newEmployee);
    }

    ////
    // UPDATE
    public async Task<ServiceResult<Employee>> Update(EmployeeDTO employeeDTO)
    {
        Employee? existingEmployee = await DbContext.Employees.FindAsync(employeeDTO.Id);

        if (existingEmployee is null)
        {
            return ServiceResult<Employee>.Failure(ResultError.NotFound, "Employee not found.");
        }

        existingEmployee.UpdateWithDTO(employeeDTO);
        await DbContext.SaveChangesAsync();

        return ServiceResult<Employee>.Success(existingEmployee);
    }

    ////
    // DELETE
    public async Task<ServiceResult> Delete(long id)
    {
        await DbContext.Employees
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync();

        return ServiceResult.Success();
    }
}