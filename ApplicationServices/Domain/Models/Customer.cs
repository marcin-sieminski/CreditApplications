using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CreditApplications.ApplicationServices.Domain.Models;

public class Customer
{
    [DisplayName("Id")]
    public int Id { get; set; }
    [DisplayName("First name")]
    [Required]
    public string CustomerFirstName { get; set; }
    [DisplayName("Last name")]
    [Required]
    public string CustomerLastName { get; set; }
    [DisplayName("Country")]
    public string Country { get; set; }
    [DisplayName("City")]
    public string City { get; set; }
    [DisplayName("Postal code")]
    public string PostalCode { get; set; }
    [DisplayName("Street")]
    public string Street { get; set; }
    [DisplayName("House number")]
    public string AddressNumber { get; set; }
    [DisplayName("Phone")]
    public string PhoneNumber { get; set; }
    [DisplayName("E-mail")]
    public string Email { get; set; }
}