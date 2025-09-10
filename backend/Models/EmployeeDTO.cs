using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class EmployeeDTO
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public Campus Campus { get; set; }
}