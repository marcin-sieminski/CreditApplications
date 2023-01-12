using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public class ApplicationStatus : EntityBase
{
    [Required] public string? ApplicationStatusName { get; set; }

    public virtual List<CreditApplication>? CreditApplications { get; set; }
}
