using System;
using CreditApplications.Mobile.Models;

namespace CreditApplications.Mobile.ViewModels;

public class NewCustomerViewModel : BaseNewItemViewModel<CustomerForView>
{
    private int _id;
    private string _customerFirstName;
    private string _customerLastName;
    private string _country;
    private string _city;
    private string _postalCode;
    private string _street;
    private string _addressNumber;
    private string _phoneNumber;
    private string _email;
        
    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }
        
    public string CustomerFirstName
    {
        get => _customerFirstName;
        set => SetProperty(ref _customerFirstName, value);
    }
        
    public string CustomerLastName
    {
        get => _customerLastName;
        set => SetProperty(ref _customerLastName, value);
    }

    public string Country
    {
        get => _country;
        set => SetProperty(ref _country, value);
    }

    public string City
    {
        get => _city;
        set => SetProperty(ref _city, value);
    }

    public string PostalCode
    {
        get => _postalCode;
        set => SetProperty(ref _postalCode, value);
    }

    public string Street
    {
        get => _street;
        set => SetProperty(ref _street, value);
    }

    public string AddressNumber
    {
        get => _addressNumber;
        set => SetProperty(ref _addressNumber, value);
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set => SetProperty(ref _phoneNumber, value);
    }

    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }


    public override bool ValidateSave()
    {
        return !String.IsNullOrWhiteSpace(CustomerFirstName)
               && !String.IsNullOrWhiteSpace(CustomerLastName);
    }

    public override CustomerForView SetItem()
    {
        return new CustomerForView()
        {
            CustomerFirstName = this.CustomerFirstName,
            CustomerLastName = this.CustomerLastName,
            Country = this.Country,
            City = this.City,
            PostalCode = this.PostalCode,
            Street = this.Street,
            AddressNumber = this.AddressNumber,
            PhoneNumber = this.PhoneNumber,
            Email = this.Email
        };
    }
}

