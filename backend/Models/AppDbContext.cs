using System.Collections;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore;

namespace WorkSense.Backend.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options)
    {
        Collections = new Hashtable
        {
            { typeof(Employee), Employees },
            { typeof(Campus), Campuses },
            { typeof(Building), Buildings },
            { typeof(Location), Locations },
            { typeof(Department), Departments },
            { typeof(JobType), JobTypes },
            { typeof(Equipment), Equipment },
            { typeof(Company), Companies },
            { typeof(WorkOrder), WorkOrders },
            { typeof(WorkAction), WorkActions },
            { typeof(SupplyOrder), SupplyOrders },
            { typeof(Attachment), Attachments },
        };
    }


    // Lookup table to avoid performance hit of using
    // reflection to retrieve DbSets programatically
    private Hashtable Collections { get; }

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


    public DbSet<TEntity> GetCollection<TEntity>() where TEntity : class
    {
        // Resulting DbSet is should not be null
        return (DbSet<TEntity>)Collections[typeof(TEntity)]!;
    }
}