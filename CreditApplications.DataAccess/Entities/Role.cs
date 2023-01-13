using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public class Role : EntityBase
{
    [Required]
    [MaxLength(250)]
    public string RoleName { get; set; }

    public virtual List<Employee> Employees { get; set; } = new List<Employee>();
}
