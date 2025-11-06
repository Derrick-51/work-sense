using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;


[ApiController]
[Route("api/employees")]
public class EmployeeController : CRUDController<Employee, long, EmployeeDTO, EmployeeDTO>
{
    public EmployeeController(EmployeeService employeeService)
        :base(employeeService)
    {
        
    }
}