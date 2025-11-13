using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Campus : BaseModel<Campus, long>
{
    //
    // PROPERTIES
    //

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    public ICollection<Building> buildings { get; } = new List<Building>();

    //
    // CONSTRUCTORS
    //

    public Campus() { }

    public Campus(Campus campus)
    {
        UpdateFieldsUsing(campus);
    }

    //
    // METHODS
    //

    public override void UpdateFieldsUsing(Campus campus)
    {
        Key = campus.Key;
        Name = campus.Name;
        Address = campus.Address;
    }
}