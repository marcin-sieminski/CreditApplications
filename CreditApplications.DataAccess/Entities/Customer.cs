using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public class Customer : EntityBase
{
    [DisplayName("Customer first name")]
    [Required]
    [MaxLength(500)]
    public string CustomerFirstName { get; set; }

    [DisplayName("Customer last name")]
    [Required]
    [MaxLength(500)]
    public string CustomerLastName { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string Country { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string City { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string PostalCode { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string Street { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string AddressNumber { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string PhoneNumber { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string Email { get; set; }

    public virtual List<CreditApplication> CreditApplications { get; set; } = new List<CreditApplication>();
}
