using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class EmployeeDTO
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public Campus Campus { get; set; } = null!;

    [Required]
    public Department Department { get; set; } = null!;

    public EmployeeDTO(Employee employee)
    {
        Id = employee.Id;
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
}