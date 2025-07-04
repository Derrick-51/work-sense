using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    public EmployeeController()
    {}

    [HttpGet]
    public ActionResult<List<Employee>> GetAll()
    {
        return EmployeeService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Employee> Get(int id)
    {
        Employee? employee = EmployeeService.Get(id);

        if(employee is null)
        {
            return NotFound();
        }

        return employee;
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        EmployeeService.Add(employee);
        return CreatedAtAction(nameof(Get), new{id = employee.Id}, employee);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Employee employee)
    {
        if(id != employee.Id)
            return BadRequest();

        Employee? foundEmployee = EmployeeService.Get(id);

        if(foundEmployee is null)
            return NotFound();

        EmployeeService.Update(employee);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Employee? foundEmployee = EmployeeService.Get(id);

        if(foundEmployee is null)
            return NotFound();

        EmployeeService.Delete(id);

        return NoContent();
    }
}