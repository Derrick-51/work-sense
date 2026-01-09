using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class BuildingDTO : ITransferObject<Building, long, BuildingDTO>
{
    [Key]
    public long Key { get; set; }

    [Required]
    public long CampusKey { get; set; } = default;

    public BuildingDTO() {}

    public BuildingDTO(Building building)
    {
        Key = building.Key;
        CampusKey = building.CampusKey;
    }

    public static implicit operator Building(BuildingDTO buildingDTO)
    {
        Building building = new Building();
        building.Key = buildingDTO.Key;
        building.CampusKey = buildingDTO.CampusKey;
        return building;
    }

    public static BuildingDTO CreateWithEntity(Building building)
    {
        return new BuildingDTO(building);
    }

    public void CopyFieldsTo(Building building)
    {
        building.Key = Key;
        building.CampusKey = CampusKey;
    }
}