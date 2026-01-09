using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.StaticAssets;

namespace WorkSense.Backend.Models;

public class WorkOrderDTO : ITransferObject<WorkOrder, long, WorkOrderDTO>
{
    [Key]
    public long Key { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;

    public DateTime RequestTimeStamp { get; set; } = DateTime.Now;

    public DateTime DueTimeStamp { get; set; } = DateTime.Now.AddDays(7.0);

    public bool IsOpen { get; set; } = true;

    [Required]
    public long RequesterKey { get; set; } = default;

    public long AssigneeKey { get; set; } = default;

    [Required]
    public long JobTypeKey { get; set; } = default;

    [Required]
    public long LocationKey { get; set; } = default;

    public WorkOrderDTO() {}

    public WorkOrderDTO(WorkOrder workOrder)
    {
        Key = workOrder.Key;
        Description = workOrder.Description;
        RequestTimeStamp = workOrder.RequestTimeStamp;
        DueTimeStamp = workOrder.DueTimeStamp;
        IsOpen = workOrder.IsOpen;
        RequesterKey = workOrder.RequesterKey;
        AssigneeKey = workOrder.AssigneeKey;
        JobTypeKey = workOrder.JobTypeKey;
        LocationKey = workOrder.LocationKey;
    }

    public static implicit operator WorkOrder(WorkOrderDTO workOrderDTO)
    {
        WorkOrder workOrder = new WorkOrder();
        workOrder.Key = workOrderDTO.Key;
        workOrder.Description = workOrderDTO.Description;
        workOrder.RequestTimeStamp = workOrderDTO.RequestTimeStamp;
        workOrder.DueTimeStamp = workOrderDTO.DueTimeStamp;
        workOrder.IsOpen = workOrderDTO.IsOpen;
        workOrder.RequesterKey = workOrderDTO.RequesterKey;
        workOrder.AssigneeKey = workOrderDTO.AssigneeKey;
        workOrder.JobTypeKey = workOrderDTO.JobTypeKey;
        workOrder.LocationKey = workOrderDTO.LocationKey;
        return workOrder;
    }

    public static WorkOrderDTO CreateWithEntity(WorkOrder workOrder)
    {
        return new WorkOrderDTO(workOrder);
    }

    public void CopyFieldsTo(WorkOrder workOrder)
    {
        workOrder.Key = Key;
        workOrder.Description = Description;
        workOrder.RequestTimeStamp = RequestTimeStamp;
        workOrder.DueTimeStamp = DueTimeStamp;
        workOrder.IsOpen = IsOpen;
        workOrder.RequesterKey = RequesterKey;
        workOrder.AssigneeKey = AssigneeKey;
        workOrder.JobTypeKey = JobTypeKey;
        workOrder.LocationKey = LocationKey;
    }
}