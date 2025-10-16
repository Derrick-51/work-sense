using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Employee : BaseModel<Employee, long>
{
    //
    // PROPERTIES
    //
    
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

    //
    // CONSTRUCTORS
    //

    public Employee() { }

    public Employee(Employee employee)
    {
        Key = employee.Key;
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        PhoneNumber = employee.PhoneNumber;
        Campus = employee.Campus;
        Department = employee.Department;
    }

    //
    // METHODS
    //

    // Update all non-key fields
    public override void UpdateFields(Employee employee)
    {
        Key = employee.Key;
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        PhoneNumber = employee.PhoneNumber;
        Campus = employee.Campus;
        Department = employee.Department;
    }
}