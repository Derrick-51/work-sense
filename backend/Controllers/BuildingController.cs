using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using WorkSense.Backend.Services.Results;


[ApiController]
[Route("api/buildings")]
public class BuildingController : CRUDController<Building, long, BuildingDTO, BuildingDTO>
{
    public BuildingController(BuildingService buildingService)
        : base(buildingService)
    {
        
    }
}