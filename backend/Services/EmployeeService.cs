using WorkSense.Backend.Models;

namespace WorkSense.Backend.Services;

public static class EmployeeService
{
    static List<Employee> Employees { get; }
    static int NextId = 4;
    static EmployeeService()
    {
        Employees = new List<Employee>
        {
            new Employee{Id = 1, FirstName = "Michael", LastName = "Jordan", PhoneNumber = "13135557293"},
            new Employee{Id = 2, FirstName = "Cave", LastName = "Johnson", PhoneNumber = "15865554277"},
            new Employee{Id = 3, FirstName = "Peter", LastName = "Parker", PhoneNumber = "13135559855"}
        };
    }

    public static List<Employee> GetAll() => Employees;

    public static Employee? Get(int id) => Employees.FirstOrDefault(e => e.Id == id);

    public static void Add(Employee employee)
    {
        employee.Id = NextId++;
        Employees.Add(employee);
    }

    public static void Update(Employee employee)
    {
        var index = Employees.FindIndex(e => e.Id == employee.Id);

        if(index == -1)
            return;

        Employees[index] = employee;
    }

    public static void Delete(int id)
    {
        Employee? employee = Get(id);

        if(employee is null)
            return;

        Employees.Remove(employee);
    }
}