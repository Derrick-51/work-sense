using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSense.Backend.Models;

public class WorkAction : BaseModel<WorkAction, long>
{
    //
    // PROPERTIES
    //
    
    [Required]
    public string Description { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; } = DateTime.Now;

    public Decimal Hours { get; set; } = 0.0m;

    public Decimal PayRate { get; set; } = 0.0m;

    // Conditional field handled by frontend
    public string? ContractorName { get; set; }

    [Required]
    [ForeignKey(nameof(WorkOrder))]
    public long WorkOrderKey { get; set; } = default;
    public WorkOrder? WorkOrder { get; set; }

    [ForeignKey(nameof(Equipment))]
    public long EquipmentKey { get; set; } = default;
    public Equipment? Equipment { get; set; }

    // Conditional field handled by frontend
    [ForeignKey(nameof(Employee))]
    public long EmployeeKey { get; set; } = default;
    public Employee? Employee { get; set; }

    // In-house database record for work that is not contracted
    [Required]
    [ForeignKey(nameof(Company))]
    public long CompanyKey { get; set; } = default;
    public Company? Company { get; set; }

    public ICollection<SupplyOrder> SupplyOrders { get; } = new List<SupplyOrder>();

    //
    // CONSTRUCTORS
    //

    public WorkAction() {}

    public WorkAction(WorkAction workAction)
    {
        UpdateFieldsUsing(workAction);
    }

    //
    // METHODS
    //

    public override void UpdateFieldsUsing(WorkAction workAction)
    {
        Key = workAction.Key;
        Description = workAction.Description;
        Timestamp = workAction.Timestamp;
        Hours = workAction.Hours;
        PayRate = workAction.PayRate;
        ContractorName = workAction.ContractorName;
        WorkOrderKey = workAction.WorkOrderKey;
        WorkOrder = workAction.WorkOrder;
        EquipmentKey = workAction.EquipmentKey;
        Equipment = workAction.Equipment;
        EmployeeKey = workAction.EmployeeKey;
        Employee = workAction.Employee;
        CompanyKey = workAction.CompanyKey;
        Company = workAction.Company;
    }
}