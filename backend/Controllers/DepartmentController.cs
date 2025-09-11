using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using WorkSense.Backend.Services.Results;


[ApiController] ;
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    // private readonly DepartmentService DepartmentService;

    // public DepartmentController(DepartmentService departmentService)
    // {
    //      DepartmentService = departmentService;
    // }

    [HttpGet]
    public async Task<ActionResult<List<Department>>> GetAll()
    {
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Department>>> GetById(long id)
    {
        return NoContent();
    }

    [HttpPost()]
    public async Task<IActionResult> Post(Department department)
    {
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, Department department)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        return NoContent();
    }
}