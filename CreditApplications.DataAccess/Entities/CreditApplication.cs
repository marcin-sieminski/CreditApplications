using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace CreditApplications.DataAccess.Entities;

public class CreditApplication : EntityBase
{
    [DisplayName("Customer")]
    [Required]
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    
    [DisplayName("Employee")]
    [Required]
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }

    [Required]
    public int ProductTypeId { get; set; }
    public virtual ProductType ProductType { get; set; }
    
    [Required]
    public DateTime DateOfSubmission { get; set; }
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

    public virtual List<Collateral> Collaterals { get; set; } = new List<Collateral>();
    public virtual List<Document> Documents { get; set; } = new List<Document>();

}
