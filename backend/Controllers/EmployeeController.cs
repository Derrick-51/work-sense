using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;


[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }

    ////
    // TODO: Implement with service
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
    {
        // return await employeeService.GetAll();
         
    }

    ////
    // TODO: Implement with service
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDTO>> GetEmployee(long id)
    {
        // Employee employee = employeeService.GetById(id);

        if(true)
        {
            return NotFound();
        }

    }

    ////
    // TODO: Implement with service
    [HttpPost]
    public async Task<IActionResult> PostEmployee(EmployeeDTO employeeDTO)
    {
        employeeService.Add(employeeDTO);

        return CreatedAtAction(
            nameof(PostEmployee),
            new { id = employeeDTO.Id },
            employeeDTO);
    }

    ////
    // TODO: Implement with service
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployee(long id, EmployeeDTO employeeDTO)
    {
        if(id != employeeDTO.Id)
            return BadRequest();

        // Employee foundEmployee = employeeService.GetById(id);

        if(true)
            return NotFound();

        // employeeService.Update(employee);
        
        return NoContent();
    }

    ////
    // TODO: Implement with service
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(long id)
    {
        // Employee foundEmployee = employeeService.GetById(id);

        if(true)
            return NotFound();

        // employeeService.Delete(id);

        return NoContent();
    }
}