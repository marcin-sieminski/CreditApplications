using System.ComponentModel;
using CreditApplications.ServiceReference;

namespace CreditApplications.Mobile.Models;

public class CustomerForView
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("First name")]
    public string CustomerFirstName { get; set; }
    
    [DisplayName("Last name")]
    public string CustomerLastName { get; set; }

    [DisplayName("Country")]
    public string Country { get; set; }
    
    [DisplayName("City")]
    public string City { get; set; }
    
    [DisplayName("Street")]
    public string Street { get; set; }
    
    [DisplayName("Postal code")]
    public string PostalCode { get; set; }

    [DisplayName("House number")]
    
    public string AddressNumber { get; set; }
    
    [DisplayName("Phone")]
    public string PhoneNumber { get; set; }
    
    [DisplayName("E-mail")]
    public string Email { get; set; }

    public CustomerForView()
    {
        
    }

    public CustomerForView(CustomerModel model)
    {
        Id = model.Id;
        CustomerFirstName = model.CustomerFirstName;
        CustomerLastName = model.CustomerLastName;
        Country = model.Country;
        City = model.City;
        PostalCode = model.PostalCode;
        Street = model.Street;
        AddressNumber = model.AddressNumber;
        PhoneNumber = model.PhoneNumber;
        Email = model.Email;
    }
}