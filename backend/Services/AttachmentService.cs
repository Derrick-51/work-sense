using WorkSense.Backend.Models;

namespace WorkSense.Backend.Services;

public class AttachmentService : CRUDService<Attachment, string>
{
    public AttachmentService(AppDbContext dbContext)
    : base(dbContext)
    { }

    //
    // Extension methods beyond basic CRUD services
    //
}