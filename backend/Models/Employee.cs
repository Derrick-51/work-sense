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

    public void UpdateWithDTO(EmployeeDTO employeeDTO)
    {
        FirstName = employeeDTO.FirstName;
        LastName = employeeDTO.LastName;
        PhoneNumber = employeeDTO.PhoneNumber;
        Campus = employeeDTO.Campus;
        Department = employeeDTO.Department;
    }
}