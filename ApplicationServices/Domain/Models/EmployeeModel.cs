using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CreditApplications.DataAccess.Entities;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class EmployeeModel
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("First name")]
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [DisplayName("Last name")]
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [DisplayName("Department")]
    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; }

    [DisplayName("Role")]
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }

    public virtual CreditApplication CreditApplications { get; set; }

    public List<DepartmentModel> AvailableDepartments { get; set; } = new();
    public List<RoleModel> AvailableRoles { get; set; } = new();

}