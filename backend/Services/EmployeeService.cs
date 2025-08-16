using WorkSense.Backend.Models;

namespace WorkSense.Backend.Services;

////
// TODO: Change interface and class to correct methods
public interface IEmployeeService
{
    public void GetAll();
    public void GetById(long id);
    public void Add(EmployeeDTO employeeDTO);
    public void Update(EmployeeDTO employeeDTO);
    public void Delete(long id);
}

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext dbContext;

    EmployeeService(AppDbContext context)
    {
        dbContext = context;
    }

    public async void GetAll()
    {

    }

    public async void GetById(long id)
    {
        
    }

    public async void Add(EmployeeDTO employeeDTO)
    {
        
    }

    public async void Update(EmployeeDTO employeeDTO)
    {
        
    }

    public async void Delete(long id)
    {
        
    }
}