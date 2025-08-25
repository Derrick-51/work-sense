using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services.Results;

namespace WorkSense.Backend.Services;

////
// TODO: Change interface and class to correct methods
public interface IEmployeeService
{
    public Task<ServiceResult<List<Employee>>> GetAll();
    public Task<ServiceResult<Employee>> GetById(long id);
    public Task<ServiceResult<Employee>> Add(EmployeeDTO employeeDTO);
    public Task<ServiceResult<Employee>> Update(EmployeeDTO employeeDTO);
    public void Delete(long id);
}

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext dbContext;

    EmployeeService(AppDbContext context)
    {
        dbContext = context;
    }

    ////
    // GET ALL
    public async Task<ServiceResult<List<Employee>>> GetAll()
    {
        List<Employee> employees = await dbContext.Employees.ToListAsync();

        if (employees is null)
        {
            return ServiceResult<List<Employee>>.Failure(ResultError.NotFound, "No Employees found.");
        }
        return ServiceResult<List<Employee>>.Success(employees);
    }

    ////
    // GET ONE (ID)
    public async Task<ServiceResult<Employee>> GetById(long id)
    {
        Employee? foundEmployee = await dbContext.Employees.FindAsync(id);

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
        Employee newEmployee = new Employee
        {
            FirstName = employeeDTO.FirstName,
            LastName = employeeDTO.LastName,
            PhoneNumber = employeeDTO.PhoneNumber
        };

        dbContext.Employees.Add(newEmployee);
        await dbContext.SaveChangesAsync();

        return ServiceResult<Employee>.Success(newEmployee);
    }

    ////
    // UPDATE
    public async Task<ServiceResult<Employee>> Update(EmployeeDTO employeeDTO)
    {
        Employee? existingEmployee = await dbContext.Employees.FindAsync(employeeDTO.Id);

        if (existingEmployee is null)
        {
            return ServiceResult<Employee>.Failure(ResultError.NotFound, "Employee not found.");
        }

        existingEmployee.UpdateWithDTO(employeeDTO);
        await dbContext.SaveChangesAsync();

        return ServiceResult<Employee>.Success(existingEmployee);
    }

    ////
    // DELETE
    public async void Delete(long id)
    {
        await dbContext.Employees
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync();
    }
}