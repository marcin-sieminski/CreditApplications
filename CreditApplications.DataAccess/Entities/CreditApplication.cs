using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public class CreditApplication : EntityBase
{
    [Required]
    public DateTime DateOfSubmission { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    [Required]
    public int ProductTypeId { get; set; }
    public virtual ProductType ProductType { get; set; }
    [Required]
    public string Currency { get; set; }
    [Required]
    public decimal AmountRequested { get; set; }
    public decimal? AmountGranted { get; set; }
    [Required]
    public int ApplicationStatusId { get; set; }
    public virtual ApplicationStatus ApplicationStatus { get; set; }
    public DateTime DateOfLastStatusChange { get; set; }
    [MaxLength(3000)]
    public string Notes { get; set; }

    public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    public virtual List<Collateral> Collaterals { get; set; } = new List<Collateral>();
    public virtual List<Document> Documents { get; set; } = new List<Document>();

}
