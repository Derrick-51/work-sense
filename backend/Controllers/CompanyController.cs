using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;
using WorkSense.Backend.Services.Results;


[ApiController]
[Route("api/companies")]
public class CompanyController : CRUDController<Company, long, CompanyDTO, CompanyDTO>
{
    public CompanyController(CompanyService companyService)
        : base(companyService)
    {
        
    }
}