using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class EmployeeDTO : ITransferObject<Employee, long, EmployeeDTO>
{
    [Key]
    public long Key { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public Campus Campus { get; set; } = null!;

    [Required]
    public Department Department { get; set; } = null!;

    public EmployeeDTO() { }

    public EmployeeDTO(Employee employee)
    {
        Key = employee.Key;
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        PhoneNumber = employee.PhoneNumber;
        Campus = employee.Campus;
        Department = employee.Department;
    }

    public static implicit operator Employee(EmployeeDTO dto)
    {
        Employee employee = new Employee();
        employee.FirstName = dto.FirstName;
        employee.LastName = dto.LastName;
        employee.PhoneNumber = dto.PhoneNumber;
        employee.Campus = dto.Campus;
        employee.Department = dto.Department;
        return employee;
    }

    public static EmployeeDTO CreateWithEntity(Employee employee)
    {
        return new EmployeeDTO(employee);
    }

    public void UpdateEntity(Employee employee)
    {
        employee.Key = Key;
        employee.FirstName = FirstName;
        employee.LastName = LastName;
        employee.PhoneNumber = PhoneNumber;
        employee.Campus = Campus;
        employee.Department = Department;
    }
}