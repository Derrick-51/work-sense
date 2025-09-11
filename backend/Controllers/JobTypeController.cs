using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using WorkSense.Backend.Services.Results;


[ApiController] ;
[Route("api/[controller]")]
public class JobTypeController : ControllerBase
{
    // private readonly JobTypeService JobTypeService;

    // public JobTypeController(JobTypeService jobTypeService)
    // {
    //      JobTypeService = jobTypeService;
    // }

    [HttpGet]
    public async Task<ActionResult<List<JobType>>> GetAll()
    {
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<JobType>>> GetById(long id)
    {
        return NoContent();
    }

    [HttpPost()]
    public async Task<IActionResult> Post(long id)
    {
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, JobType jobType)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        return NoContent();
    }
}