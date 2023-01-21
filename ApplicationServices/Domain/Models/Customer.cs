namespace CreditApplications.ApplicationServices.Domain.Models;

public class Customer
{
    public int Id { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Street { get; set; }
    public string AddressNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}