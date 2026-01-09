using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class WorkActionDTO : ITransferObject<WorkAction, long, WorkActionDTO>
{
    [Key]
    public long Key { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; } = DateTime.Now;

    public decimal Hours { get; set; } = default;

    public decimal PayRate { get; set; } = default;

    public string? ContractorName { get; set; }

    [Required]
    public long WorkOrderKey { get; set; } = default;

    public long EquipmentKey { get; set; } = default;

    public long EmployeeKey { get; set; } = default;

    public long CompanyKey { get; set; } = default;

    public WorkActionDTO() {}

    public WorkActionDTO(WorkAction workAction)
    {
        Key = workAction.Key;
        Description = workAction.Description;
        Timestamp = workAction.Timestamp;
        Hours = workAction.Hours;
        PayRate = workAction.PayRate;
        ContractorName = workAction.ContractorName;
        WorkOrderKey = workAction.WorkOrderKey;
        EquipmentKey = workAction.EquipmentKey;
        EmployeeKey = workAction.EmployeeKey;
        CompanyKey = workAction.CompanyKey;
    }

    public static implicit operator WorkAction(WorkActionDTO workActionDTO)
    {
        WorkAction workAction = new WorkAction();
        workAction.Key = workActionDTO.Key;
        workAction.Description = workActionDTO.Description;
        workAction.Timestamp = workActionDTO.Timestamp;
        workAction.Hours = workActionDTO.Hours;
        workAction.PayRate = workActionDTO.PayRate;
        workAction.ContractorName = workActionDTO.ContractorName;
        workAction.WorkOrderKey = workActionDTO.WorkOrderKey;
        workAction.EquipmentKey = workActionDTO.EquipmentKey;
        workAction.EmployeeKey = workActionDTO.EmployeeKey;
        workAction.CompanyKey = workActionDTO.CompanyKey;
        return workAction;
    }

    public static WorkActionDTO CreateWithEntity(WorkAction workAction)
    {
        return new WorkActionDTO(workAction);
    }

    public void CopyFieldsTo(WorkAction workAction)
    {
        workAction.Key = Key;
        workAction.Description = Description;
        workAction.Timestamp = Timestamp;
        workAction.Hours = Hours;
        workAction.PayRate = PayRate;
        workAction.ContractorName = ContractorName;
        workAction.WorkOrderKey = WorkOrderKey;
        workAction.EquipmentKey = EquipmentKey;
        workAction.EmployeeKey = EmployeeKey;
        workAction.CompanyKey = CompanyKey;
    }
}