using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class WorkOrder
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;

    public DateTime RequestTimeStamp { get; set; } = DateTime.Now;

    public DateTime DueTimeStamp { get; set; } = DateTime.Now.AddDays(7.0);

    public bool IsOpen { get; set; } = true;

    [Required]
    public Employee Requester { get; set; } = null!;

    // Placeholder database record for unassigned work orders
    public Employee Assignee { get; set; } = null!;

    [Required]
    public JobType JobType { get; set; } = null!;

    [Required]
    public Location Location { get; set; } = null!;

    public ICollection<WorkAction> WorkActions { get; } = new List<WorkAction>();

    public ICollection<Attachment> Attachments { get; } = new List<Attachment>();
}