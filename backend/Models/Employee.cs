namespace WorkSense.Backend.Models;

public class Employee
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public void UpdateWithDTO(EmployeeDTO employeeDTO)
    {
        FirstName = employeeDTO.FirstName;
        LastName = employeeDTO.LastName;
        PhoneNumber = employeeDTO.PhoneNumber;
    }
}