using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Company : BaseModel<Company, long>
{
    //
    // PROPERTIES
    //

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    //
    // CONSTRUCTORS
    //

    public Company() {}

    public Company(Company company)
    {
        UpdateFieldsUsing(company);
    }

    //
    // METHODS
    //

    public override void UpdateFieldsUsing(Company company)
    {
        Key = company.Key;
        Name = company.Name;
        Address = company.Address;
    }
}