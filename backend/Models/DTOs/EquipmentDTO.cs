using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class EquipmentDTO : ITransferObject<Equipment, long, EquipmentDTO>
{
    [Key]
    public long Key { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string Manufacturer { get; set; } = string.Empty;

    [Required]
    public string Serial { get; set; } = string.Empty;

    public DateOnly InstallDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Required]
    public long LocationKey { get; set; } = default;

    public EquipmentDTO() {}

    public EquipmentDTO(Equipment equipment)
    {
        Key = equipment.Key;
        Name = equipment.Name;
        Manufacturer = equipment.Manufacturer;
        Serial = equipment.Serial;
        InstallDate = equipment.InstallDate;
        LocationKey = equipment.LocationKey;
    }

    public static implicit operator Equipment(EquipmentDTO equipmentDTO)
    {
        Equipment equipment = new Equipment();
        equipment.Key = equipmentDTO.Key;
        equipment.Name = equipmentDTO.Name;
        equipment.Manufacturer = equipmentDTO.Manufacturer;
        equipment.Serial = equipmentDTO.Serial;
        equipment.InstallDate = equipmentDTO.InstallDate;
        equipment.LocationKey = equipmentDTO.LocationKey;
        return equipment;
    }

    public static EquipmentDTO CreateWithEntity(Equipment equipment)
    {
        return new EquipmentDTO(equipment);
    }

    public void CopyFieldsTo(Equipment equipment)
    {
        equipment.Key = Key;
        equipment.Name = Name;
        equipment.Manufacturer = Manufacturer;
        equipment.Serial = Serial;
        equipment.InstallDate = InstallDate;
        equipment.LocationKey = LocationKey;
    }
}