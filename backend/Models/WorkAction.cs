using System.ComponentModel.DataAnnotations;

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
    public WorkOrder WorkOrder { get; set; } = null!;

    public Equipment? Equipment { get; set; }

    // Conditional field handled by frontend
    public Employee? Employee { get; set; }

    // In-house database record for work that is not contracted
    [Required]
    public Company Company { get; set; } = null!;

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
        WorkOrder = workAction.WorkOrder;
        Equipment = workAction.Equipment;
        Employee = workAction.Employee;
        Company = workAction.Company;
    }
}