using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public class Employee : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string? FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string? LastName { get; set; }
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }

    public List<CreditApplication>? CreditApplications { get; set; }
}
