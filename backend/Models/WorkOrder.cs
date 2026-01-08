using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSense.Backend.Models;

public class WorkOrder : BaseModel<WorkOrder, long>
{
    //
    // PROPERTIES
    //
    
    [Required]
    public string Description { get; set; } = string.Empty;

    public DateTime RequestTimeStamp { get; set; } = DateTime.Now;

    public DateTime DueTimeStamp { get; set; } = DateTime.Now.AddDays(7.0);

    public bool IsOpen { get; set; } = true;

    [Required]
    [ForeignKey(nameof(Employee))]
    public long RequesterKey { get; set; } = default;
    public Employee? Requester { get; set; }

    [ForeignKey(nameof(Employee))]
    // Placeholder database record for unassigned work orders
    public long AssigneeKey { get; set; } = default;
    public Employee? Assignee { get; set; }

    [Required]
    [ForeignKey(nameof(JobType))]
    public long JobTypeKey { get; set; } = default;
    public JobType? JobType { get; set; }

    [Required]
    [ForeignKey(nameof(Location))]
    public long LocationKey { get; set; } = default;
    public Location? Location { get; set; }

    public ICollection<WorkAction> WorkActions { get; } = new List<WorkAction>();

    public ICollection<Attachment> Attachments { get; } = new List<Attachment>();

    //
    // CONSTRUCTORS
    //

    public WorkOrder() {}

    public WorkOrder(WorkOrder workOrder) 
    {
        UpdateFieldsUsing(workOrder);
    }

    //
    // METHODS
    //

    public override void UpdateFieldsUsing(WorkOrder workOrder)
    {
        Key = workOrder.Key;
        Description = workOrder.Description;
        RequestTimeStamp = workOrder.RequestTimeStamp;
        DueTimeStamp = workOrder.DueTimeStamp;
        IsOpen = workOrder.IsOpen;
        Requester = workOrder.Requester;
        Assignee = workOrder.Assignee;
        JobType = workOrder.JobType;
        Location = workOrder.Location;
    }
}