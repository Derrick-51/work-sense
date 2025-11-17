using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    [ForeignKey(nameof(Campus))]
    public long CampusKey { get; set; } = default;
    public Campus? Campus { get; set; }

    [Required]
    [ForeignKey(nameof(Department))]
    public long DepartmentKey { get; set; } = default;
    public Department? Department { get; set; }

    //
    // CONSTRUCTORS
    //

    public Employee() { }

    public Employee(Employee employee)
    {
        UpdateFieldsUsing(employee);
    }

    //
    // METHODS
    //

    public override void UpdateFieldsUsing(Employee employee)
    {
        Key = employee.Key;
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        PhoneNumber = employee.PhoneNumber;
        CampusKey = employee.CampusKey;
        Campus = employee.Campus;
        DepartmentKey = employee.DepartmentKey;
        Department = employee.Department;
    }
}