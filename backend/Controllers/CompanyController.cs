using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using WorkSense.Backend.Services.Results;


[ApiController] ;
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    // private readonly CompanyService CompanyService;

    // public CompanyController(CompanyService companyService)
    // {
    //      CompanyService = companyService;
    // }

    [HttpGet]
    public async Task<ActionResult<List<Company>>> GetAll()
    {
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Company>>> GetById(long id)
    {
        return NoContent();
    }

    [HttpPost()]
    public async Task<IActionResult> Post(Company company)
    {
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, Company company)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        return NoContent();
    }
}