using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using WorkSense.Backend.Services.Results;


[ApiController] ;
[Route("api/[controller]")]
public class WorkActionController : ControllerBase
{
    // private readonly WorkActionService WorkActionService;

    // public WorkActionController(WorkActionService workActionService)
    // {
    //      WorkActionService = workActionService;
    // }

    [HttpGet]
    public async Task<ActionResult<List<WorkAction>>> GetAll()
    {
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<WorkAction>>> GetById(long id)
    {
        return NoContent();
    }

    [HttpPost()]
    public async Task<IActionResult> Post(WorkAction workAction)
    {
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, WorkAction workAction)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        return NoContent();
    }
}