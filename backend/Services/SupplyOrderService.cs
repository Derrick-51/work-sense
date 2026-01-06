using WorkSense.Backend.Models;

namespace WorkSense.Backend.Services;

public class SupplyOrderService : CRUDService<SupplyOrder, long>
{
    public SupplyOrderService(AppDbContext dbContext)
    : base(dbContext)
    { }

    //
    // Extension methods beyond basic CRUD services
    //
}