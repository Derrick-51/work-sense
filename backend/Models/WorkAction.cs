using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class WorkAction
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Description { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.Now;

    public Decimal Hours { get; set; } = 0.0m;

    public Decimal PayRate { get; set; } = 0.0m;

    // Conditional field handled by frontend
    public string? ContractorName { get; set; } = string.Empty;

    [Required]
    public WorkOrder WorkOrder { get; set; }

    public Equipment? Equipment { get; set; }

    // Conditional field handled by frontend
    public Employee? Employee { get; set; }

    // In-house database record for work that is not contracted
    [Required]
    public Company Company { get; set; }

    public ICollection<SupplyOrder> SupplyOrders { get; } = new List<SupplyOrder>();
}