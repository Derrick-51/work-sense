using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using WorkSense.Backend.Services.Results;


[ApiController]
[Route("api/jobtypes")]
public class JobTypeController : CRUDController<JobType, long, JobTypeDTO, JobTypeDTO>
{
    public JobTypeController(JobTypeService jobTypeService)
        : base(jobTypeService)
    {
        
    }
}