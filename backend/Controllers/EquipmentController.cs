using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using WorkSense.Backend.Services.Results;


[ApiController]
[Route("api/equipment")]
public class EquipmentController : CRUDController<Equipment, long, EquipmentDTO, EquipmentDTO>
{
    public EquipmentController(EquipmentService equipmentService)
        : base(equipmentService)
    {
        
    }
}