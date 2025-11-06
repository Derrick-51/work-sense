using System.ComponentModel.DataAnnotations;

namespace WorkSense.Backend.Models;

public class DepartmentDTO : ITransferObject<Department, long, DepartmentDTO>
{
    [Key]
    public long Key { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public DepartmentDTO() { }

    public DepartmentDTO(Department department)
    {
        Key = department.Key;
        Name = department.Name;
    }

    public static implicit operator Department(DepartmentDTO dto)
    {
        Department department = new Department();
        department.Key = dto.Key;
        department.Name = dto.Name;
        return department;
    }

    public static DepartmentDTO CreateWithEntity(Department department)
    {
        return new DepartmentDTO(department);
    }
    
    public void UpdateEntity(Department department)
    {
        department.Key = Key;
        department.Name = Name;
    }
}