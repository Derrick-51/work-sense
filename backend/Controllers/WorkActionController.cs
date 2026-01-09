using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using WorkSense.Backend.Services.Results;


[ApiController]
[Route("api/workactions")]
public class WorkActionController : CRUDController<WorkAction, long, WorkActionDTO, WorkActionDTO>
{
    public WorkActionController(WorkActionService workActionService)
        : base(workActionService)
    {
        
    }
}