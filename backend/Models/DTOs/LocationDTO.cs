using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class LocationDTO : ITransferObject<Location, long, LocationDTO>
{
    [Key]
    public long Key { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public long BuildingKey { get; set; } = default;

    public LocationDTO() {}

    public LocationDTO(Location location)
    {
        Key = location.Key;
        Name = location.Name;
        BuildingKey = location.BuildingKey;
    }

    public static implicit operator Location(LocationDTO locationDTO)
    {
        Location location = new Location();
        location.Key = locationDTO.Key;
        location.Name = locationDTO.Name;
        location.BuildingKey = locationDTO.BuildingKey;
        return location;
    }

    public static LocationDTO CreateWithEntity(Location location)
    {
        return new LocationDTO(location);
    }

    public void CopyFieldsTo(Location location)
    {
        Key = location.Key;
        Name = location.Name;
        BuildingKey = location.BuildingKey;
    }
}