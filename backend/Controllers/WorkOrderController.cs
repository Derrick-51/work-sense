using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using WorkSense.Backend.Services.Results;


[ApiController]
[Route("api/workorders")]
public class WorkOrderController : CRUDController<WorkOrder, long, WorkOrderDTO, WorkOrderDTO>
{
    public WorkOrderController(WorkOrderService workOrderService)
        : base(workOrderService)
    {
        
    }
}