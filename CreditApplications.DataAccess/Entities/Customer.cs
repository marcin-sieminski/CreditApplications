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
    
    [MaxLength(500)]
    public string Country { get; set; }
    
    [MaxLength(500)]
    public string City { get; set; }
    
    [MaxLength(100)]
    public string PostalCode { get; set; }
    
    [MaxLength(500)]
    public string Street { get; set; }
    
    [MaxLength(100)]
    public string AddressNumber { get; set; }
    
    [MaxLength(500)]
    public string PhoneNumber { get; set; }
    
    [MaxLength(500)]
    public string Email { get; set; }

    public virtual List<CreditApplication> CreditApplications { get; set; } = new List<CreditApplication>();
}
