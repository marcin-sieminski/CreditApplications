using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CreditApplications.DataAccess.Entities;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class EmployeeModel
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }

    public virtual List<CreditApplication> CreditApplications { get; set; } = new List<CreditApplication>();

}