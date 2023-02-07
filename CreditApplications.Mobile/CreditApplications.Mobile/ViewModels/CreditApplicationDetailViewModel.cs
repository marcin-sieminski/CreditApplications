using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using CreditApplications.Mobile.Models;
using CreditApplications.Mobile.Views;
using Xamarin.Forms;

namespace CreditApplications.Mobile.ViewModels;

public class CreditApplicationDetailViewModel : BaseItemDetailViewModel<CreditApplicationForView>, IQueryAttributable  
{
    public CreditApplicationDetailViewModel() : base("Credit application details")
    {

    }

    private int _id;
    private string _customerFirstName;
    private string _customerLastName;
    private string _productType;
    private string _currency;
    private decimal _amountRequested;
    private decimal _amountGranted;
    private DateTime _dateOfSubmission;
    private DateTime _dateOfLastStatusChange;
    private string _applicationStatus;
    private string _notes;

    public int Id
    {
        get => _id;
        set
        {
            SetProperty(ref _id, value);
            GetItem(value);
        }
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

    public string ProductType
    {
        get => _productType;
        set => SetProperty(ref _productType, value);
    }

    public string ApplicationStatus
    {
        get => _applicationStatus;
        set => SetProperty(ref _applicationStatus, value);
    }

    public string Currency
    {
        get => _currency;
        set => SetProperty(ref _currency, value);
    }

    public decimal AmountRequested
    {
        get => _amountRequested;
        set => SetProperty(ref _amountRequested, value);
    }

    public decimal AmountGranted
    {
        get => _amountGranted;
        set => SetProperty(ref _amountGranted, value);
    }

    public DateTime DateOfSubmission
    {
        get => _dateOfSubmission;
        set => SetProperty(ref _dateOfSubmission, value);
    }

    public DateTime DateOfLastStatusChange
    {
        get => _dateOfLastStatusChange;
        set => SetProperty(ref _dateOfLastStatusChange, value);
    }

    public string Notes
    {
        get => _notes;
        set => SetProperty(ref _notes, value);
    }

    public async void GetItem(int itemId)
    {
        try
        {
            var item = await DataStore.GetItemAsync(itemId);
            CustomerFirstName = item.CustomerFirstName;
            CustomerLastName = item.CustomerLastName;
            ProductType = item.ProductTypeName;
            Currency = item.Currency;
            AmountRequested = item.AmountRequested;
            AmountGranted = item.AmountGranted;
            DateOfSubmission = item.DateOfSubmission;
            DateOfLastStatusChange = item.DateOfLastStatusChange;
            Notes = item.Notes;
            ApplicationStatus = item.ApplicationStatus;
        }
        catch (Exception)
        {
            Debug.WriteLine("Failed to Load Item");
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, string> query)
    {
        var id = HttpUtility.UrlDecode(query["Id"]);  
        Id = int.Parse(id); 
    }

    public override async void GoToEditPage()
    {
        await Shell.Current.GoToAsync($"{nameof(CreditApplicationEditPage)}?Id={Id}");
    }

    public override int GetIdToDelete()
    {
        return Id;
    }
}

