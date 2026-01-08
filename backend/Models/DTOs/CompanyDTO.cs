using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class CompanyDTO : ITransferObject<Company, long, CompanyDTO>
{
    [Key]
    public long Key { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    public CompanyDTO() {}

    public CompanyDTO(Company company)
    {
        Key = company.Key;
        Name = company.Name;
        Address = company.Address;
    }

    public static implicit operator Company(CompanyDTO companyDTO)
    {
        Company company = new Company();
        company.Key = companyDTO.Key;
        company.Name = companyDTO.Name;
        company.Address = companyDTO.Address;
        return company;
    }

    public static CompanyDTO CreateWithEntity(Company company)
    {
        return new CompanyDTO(company);
    }

    public void CopyFieldsTo(Company company)
    {
        company.Key = Key;
        company.Name = Name;
        company.Address = Address;
    }
}