using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Attachment
{
    [Key]
    [Required]
    public string Url { get; set; } = string.Empty;

    [Required]
    public WorkOrder WorkOrder { get; set; } = null!;
}