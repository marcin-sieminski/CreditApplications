using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public class Department : EntityBase
{
    [Required]
    [MaxLength(250)]
    public string DepartmentName { get; set; }

    public virtual List<Employee>? Employees { get; set; }
}
