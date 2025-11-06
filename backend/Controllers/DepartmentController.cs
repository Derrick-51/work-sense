using Microsoft.AspNetCore.Mvc;

using WorkSense.Backend.Models;
using WorkSense.Backend.Services;


[ApiController]
[Route("api/departments")]
public class DepartmentController : CRUDController<Department, long, DepartmentDTO, DepartmentDTO>
{
    public DepartmentController(DepartmentService departmentService)
        :base(departmentService)
    {
        
    }
}