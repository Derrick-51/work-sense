using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSense.Backend.Models;

public class Attachment : BaseModel<Attachment, string>
{
    //
    // PROPERTIES
    //
    
    public string? Url => Key;

    [Required]
    [ForeignKey(nameof(WorkOrder))]
    public long WorkOrderKey { get; set; }
    public WorkOrder? WorkOrder { get; set; }

    //
    // CONSTRUCTORS
    //

    public Attachment() {}

    public Attachment(Attachment attachment)
    {
        UpdateFieldsUsing(attachment);
    }

    //
    // METHODS
    //

    public override void UpdateFieldsUsing(Attachment attachment)
    {
        Key = attachment.Key;
        WorkOrder = attachment.WorkOrder;
    }
}