using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Location : BaseModel<Location, long>
{
    //
    // PROPERTIES
    //
    
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public Building Building { get; set; } = null!;

    //
    // CONSTRUCTORS
    //

    public Location() {}

    public Location(Location location)
    {
        UpdateFieldsUsing(location);
    }

    //
    // METHODS
    //

    public override void UpdateFieldsUsing(Location location)
    {
        Key = location.Key;
        Name = location.Name;
        Building = location.Building;
    }
}