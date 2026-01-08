using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSense.Backend.Models;

public class Equipment : BaseModel<Equipment, long>
{
    //
    // PROPERTIES
    //
    
    [Required]
    public string Name { get; set; } = string.Empty;

    public string Manufacturer { get; set; } = string.Empty;

    [Required]
    public string Serial { get; set; } = string.Empty;

    public DateOnly InstallDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Required]
    [ForeignKey(nameof(Location))]
    public long LocationKey { get; set; } = default;
    public Location? Location { get; set; }

    //
    // CONSTRUCTORS
    //

    public Equipment() {}

    public Equipment(Equipment equipment) 
    {
        UpdateFieldsUsing(equipment);
    }

    //
    // METHODS
    //

    public override void UpdateFieldsUsing(Equipment equipment)
    {
        Key = equipment.Key;
        Name = equipment.Name;
        Manufacturer = equipment.Manufacturer;
        Serial = equipment.Serial;
        InstallDate = equipment.InstallDate;
        Location = equipment.Location;
    }
}