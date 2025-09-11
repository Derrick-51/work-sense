using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using WorkSense.Backend.Services.Results;


[ApiController] ;
[Route("api/[controller]")]
public class WorkOrderController : ControllerBase
{
    // private readonly WorkOrderService WorkOrderService;

    // public WorkOrderController(WorkOrderService workOrderService)
    // {
    //      WorkOrderService = workOrderService;
    // }

    [HttpGet]
    public async Task<ActionResult<List<WorkOrder>>> GetAll()
    {
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<WorkOrder>>> GetById(long id)
    {
        return NoContent();
    }

    [HttpPost()]
    public async Task<IActionResult> Post(WorkOrder workOrder)
    {
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, WorkOrder workOrder)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        return NoContent();
    }
}