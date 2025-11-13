using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class SupplyOrder : BaseModel<SupplyOrder, long>
{
    //
    // PROPERTIES
    //
    
    public Decimal Cost { get; set; } = 0.00m;

    public string PartName { get; set; } = string.Empty;

    [Required]
    public WorkAction WorkAction { get; set; } = null!;

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
        WorkAction = supplyOrder.WorkAction;
    }
}