using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;


[ApiController]
[Route("api/campuses")]
public class CampusController : CRUDController<Campus, long, CampusDTO, CampusDTO>
{
    public CampusController(CampusService campusService)
        : base(campusService)
    {
        
    }
}