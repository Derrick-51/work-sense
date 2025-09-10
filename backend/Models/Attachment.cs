using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class Attachment
{
    [Key]
    public string Url { get; set; }

    [Required]
    public WorkOrder WorkOrder { get; set; }
}