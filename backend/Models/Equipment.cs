using System.ComponentModel.DataAnnotations;

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
    public Location Location { get; set; } = null!;

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