using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class CustomerModel
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("First name")]
    [Required]
    [MaxLength(50)]
    public string CustomerFirstName { get; set; }
    
    [DisplayName("Last name")]
    [Required]
    [MaxLength(100)]
    public string CustomerLastName { get; set; }

    [DisplayName("Country")]
    [MaxLength(50)]
    public string Country { get; set; }
    
    [DisplayName("City")]
    [MaxLength(50)]
    public string City { get; set; }
    
    [DisplayName("Postal code")]
    [MaxLength(10)]
    public string PostalCode { get; set; }
    
    [DisplayName("Street")]
    public string Street { get; set; }
    
    [DisplayName("House number")]
    [MaxLength(10)]
    
    public string AddressNumber { get; set; }
    
    [DisplayName("Phone")]
    [MaxLength(20)]
    public string PhoneNumber { get; set; }
    
    [DisplayName("E-mail")]
    [EmailAddress]
    public string Email { get; set; }
}