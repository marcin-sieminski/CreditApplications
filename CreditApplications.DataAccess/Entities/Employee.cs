using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public class Employee : EntityBase
{
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
    //public virtual CreditApplication CreditApplication { get; set; }
    
}
