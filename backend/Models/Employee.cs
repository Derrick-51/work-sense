using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Employee
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    // TODO: Add regular expression validator [RegularExpression(@"")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public Campus Campus { get; set; }

    [Required]
    public Department Department { get; set; }

    public void UpdateWithDTO(EmployeeDTO employeeDTO)
    {
        FirstName = employeeDTO.FirstName;
        LastName = employeeDTO.LastName;
        PhoneNumber = employeeDTO.PhoneNumber;
    }
}