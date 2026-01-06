using WorkSense.Backend.Models;

namespace WorkSense.Backend.Services;

public class WorkOrderService : CRUDService<WorkOrder, long>
{
    public WorkOrderService(AppDbContext dbContext)
    : base(dbContext)
    { }

    //
    // Extension methods beyond basic CRUD services
    //
}