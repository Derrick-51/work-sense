using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSense.Backend.Models;

public class SupplyOrder : BaseModel<SupplyOrder, long>
{
    //
    // PROPERTIES
    //
    
    public Decimal Cost { get; set; } = 0.00m;

    public string PartName { get; set; } = string.Empty;

    [Required]
    [ForeignKey(nameof(WorkAction))]
    public long WorkActionKey { get; set; } = default;
    public WorkAction? WorkAction { get; set; }

    //
    // CONSTRUCTORS
    //

    public SupplyOrder() {}

    public SupplyOrder(SupplyOrder supplyOrder)
    {
        UpdateFieldsUsing(supplyOrder);
    }

    //
    // METHODS
    //

    public override void UpdateFieldsUsing(SupplyOrder supplyOrder)
    {
        Key = supplyOrder.Key;
        Cost = supplyOrder.Cost;
        PartName = supplyOrder.PartName;
        WorkActionKey = supplyOrder.WorkActionKey;
        WorkAction = supplyOrder.WorkAction;
    }
}