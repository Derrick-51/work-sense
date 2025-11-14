using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace WorkSense.Backend.Models;

public class CampusDTO : ITransferObject<Campus, long, CampusDTO>
{
    [Key]
    public long Key { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    public CampusDTO() { }

    public CampusDTO(Campus campus)
    {
        Key = campus.Key;
        Name = campus.Name;
        Address = campus.Address;
    }

    public static implicit operator Campus(CampusDTO dto)
    {
        Campus campus = new Campus();
        campus.Key = dto.Key;
        campus.Name = dto.Name;
        return campus;
    }

    public static CampusDTO CreateWithEntity(Campus campus)
    {
        return new CampusDTO(campus);
    }

    public void CopyFieldsTo(Campus campus)
    {
        campus.Key = Key;
        campus.Name = Name;
        campus.Address = Address;
    }
}