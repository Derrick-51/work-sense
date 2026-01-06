using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSense.Backend.Models;

public class Building : BaseModel<Building, long>
{
    //
    // PROPERTIES
    //

    [Required]
    [ForeignKey(nameof(Campus))]
    public long CampusKey { get; set; }
    public Campus? Campus { get; set; }

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