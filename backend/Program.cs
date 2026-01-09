using WorkSense.Backend;
using Microsoft.EntityFrameworkCore;
using WorkSense.Backend.Services;
using WorkSense.Backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject custom services
builder.Services.AddScoped<AttachmentService, AttachmentService>();
builder.Services.AddScoped<BuildingService, BuildingService>();
builder.Services.AddScoped<CampusService, CampusService>();
builder.Services.AddScoped<CompanyService, CompanyService>();
builder.Services.AddScoped<DepartmentService, DepartmentService>();
builder.Services.AddScoped<EmployeeService, EmployeeService>();
builder.Services.AddScoped<EquipmentService, EquipmentService>();
builder.Services.AddScoped<JobTypeService, JobTypeService>();
builder.Services.AddScoped<LocationService, LocationService>();
builder.Services.AddScoped<SupplyOrderService, SupplyOrderService>();
builder.Services.AddScoped<WorkActionService, WorkActionService>();
builder.Services.AddScoped<WorkOrderService, WorkOrderService>();

// Database connection configuration
// Temporary connection string for development
builder.Services.AddDbContextPool<AppDbContext>(opt =>
    opt.UseNpgsql("Server=localhost; Port=5432; Database=worksense; User Id=postgres; Password=admin; CommandTimeout=10;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
