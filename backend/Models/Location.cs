using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSense.Backend.Models;

public class Location : BaseModel<Location, long>
{
    //
    // PROPERTIES
    //
    
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [ForeignKey(nameof(Building))]
    public long BuildingKey { get; set; } = default;
    public Building? Building { get; set; }

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
        BuildingKey = location.BuildingKey;
        Building = location.Building;
    }
}