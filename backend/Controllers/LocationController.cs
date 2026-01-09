using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using WorkSense.Backend.Services.Results;


[ApiController]
[Route("api/locations")]
public class LocationController : CRUDController<Location, long, LocationDTO, LocationDTO>
{
    public LocationController(LocationService locationService)
        : base(locationService)
    {
        
    }
}