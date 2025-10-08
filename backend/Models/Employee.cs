using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Employee
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    // TODO: Add regular expression validator [RegularExpression(@"")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public Campus Campus { get; set; } = null!;

    [Required]
    public Department Department { get; set; } = null!;

    public Employee() { }

    public Employee(Employee employee)
    {
        Id = employee.Id;
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        PhoneNumber = employee.PhoneNumber;
        Campus = employee.Campus;
        Department = employee.Department;
    }

    // Update all non-key fields
    public void UpdateFields(Employee employee)
    {
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        PhoneNumber = employee.PhoneNumber;
        Campus = employee.Campus;
        Department = employee.Department;
    }
}