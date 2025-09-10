using Microsoft.EntityFrameworkCore;

namespace WorkSense.Backend.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options)
    { }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Campus> Campuses { get; set; }

    public DbSet<Building> Buildings { get; set; }

    public DbSet<Location> Locations { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<JobType> JobTypes { get; set; }

    public DbSet<Equipment> Equipment { get; set; }

    public DbSet<Company> Companies { get; set; }

    public DbSet<WorkOrder> WorkOrders { get; set; }

    public DbSet<WorkAction> WorkActions { get; set; }

    public DbSet<SupplyOrder> SupplyOrders { get; set; }

    public DbSet<Attachment> Attachments { get; set; }
}