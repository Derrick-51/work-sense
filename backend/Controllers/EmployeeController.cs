using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using WorkSense.Backend.Services.Results;


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
    // GET ALL
    [HttpGet]
    public async Task<ActionResult<List<EmployeeDTO>>> GetEmployees()
    {
        ServiceResult<List<Employee>> result = await employeeService.GetAll();

        if (result.IsError)
        {
            switch (result.Error)
            {
                case ResultError.NotFound:
                    return NotFound();
                case ResultError.NullReturnValue:
                    // TODO: Log null value error
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // Null value only occurs as error and is handled above
        List<Employee> employees = result.Value!;

        return Ok(employees);
    }

    ////
    // GET ONE (ID)
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDTO>> GetEmployee(long id)
    {
        ServiceResult<Employee> result = await employeeService.GetById(id);

        if (result.IsError)
        {
            switch (result.Error)
            {
                case ResultError.NotFound:
                    return NotFound();
                case ResultError.NullReturnValue:
                    // TODO: Log null value error
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // Null value only occurs as error and is handled above
        Employee employee = result.Value!;

        return Ok(employee);
    }

    ////
    // POST
    [HttpPost]
    public async Task<IActionResult> PostEmployee(EmployeeDTO employeeDTO)
    {
        ServiceResult<Employee> result = await employeeService.Add(employeeDTO);

        if (result.IsError)
        {
            switch (result.Error)
            {
                case ResultError.BadRequest:
                    return BadRequest();
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        return CreatedAtAction(
                    nameof(PostEmployee),
                    new { id = employeeDTO.Id },
                    employeeDTO);
    }

    ////
    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployee(long id, EmployeeDTO employeeDTO)
    {
        if (id != employeeDTO.Id)
            return BadRequest();

        ServiceResult<Employee> result = await employeeService.Update(employeeDTO);

        if (result.IsError)
        {
            switch (result.Error)
            {
                case ResultError.NotFound:
                    return NotFound();
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        return NoContent();
    }

    ////
    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(long id)
    {
        ServiceResult result = await employeeService.Delete(id);

        if (result.IsError)
            return StatusCode(StatusCodes.Status500InternalServerError);

        return NoContent();
    }
}