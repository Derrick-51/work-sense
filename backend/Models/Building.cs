using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Building : BaseModel<Building, long>
{
    //
    // PROPERTIES
    //

    [Required]
    public Campus Campus { get; set; } = null!;

    public ICollection<Location> locations { get; } = new List<Location>();

    //
    // CONSTRUCTORS
    //

    public Building() {}

    public Building(Building building)
    {
        UpdateFieldsUsing(building);
    }

    //
    // METHODS
    //

    public override void UpdateFieldsUsing(Building building)
    {
        Key = building.Key;
        Campus = building.Campus;
    }
}