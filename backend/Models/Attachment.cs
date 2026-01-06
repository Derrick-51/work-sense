using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Attachment : BaseModel<Attachment, string>
{
    //
    // PROPERTIES
    //
    
    public string? Url => Key;

    [Required]
    public WorkOrder WorkOrder { get; set; } = null!;

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