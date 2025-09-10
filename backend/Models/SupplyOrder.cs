using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class SupplyOrder
{
    [Key]
    public long Id { get; set; }

    public Decimal Cost { get; set; } = 0.00m;

    public string PartName { get; set; } = string.Empty;

    [Required]
    public WorkAction WorkAction { get; set; } = null!;
}