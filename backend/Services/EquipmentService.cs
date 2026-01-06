using WorkSense.Backend.Models;

namespace WorkSense.Backend.Services;

public class EquipmentService : CRUDService<Equipment, long>
{
    public EquipmentService(AppDbContext dbContext)
    : base(dbContext)
    { }

    //
    // Extension methods beyond basic CRUD services
    //
}