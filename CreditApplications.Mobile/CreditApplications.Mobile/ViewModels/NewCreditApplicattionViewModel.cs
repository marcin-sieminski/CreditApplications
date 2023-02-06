using System;
using System.Collections.Generic;
using CreditApplications.Mobile.Models;
using CreditApplications.Mobile.Services;
using CreditApplications.ServiceReference;

namespace CreditApplications.Mobile.ViewModels;

public class NewCreditApplicationViewModel : BaseNewItemViewModel<CreditApplicationForView>
{
    private int _id;
    private CustomerForView _selectedCustomer;
    private ProductTypeForView _selectedProductType;
    private string _currency;
    private decimal _amountRequested;
    private decimal _amountGranted;
    private DateTime _dateOfSubmission;
    private DateTime _dateOfLastStatusChange;
    private ApplicationStatusForView _selectedApplicationStatus;
    private string _notes;

    public List<CustomerForView> Customers => new CustomerDataStore().Items;
    public List<ProductTypeForView> ProductTypes => new ProductTypeDataStore().Items;
    public List<ApplicationStatusForView> ApplicationStatuses => new ApplicationStatusDataStore().Items;

    public NewCreditApplicationViewModel()
    {
        _selectedCustomer = new CustomerForView();
        DateOfSubmission  = DateTime.Now;
        DateOfLastStatusChange = DateTime.Now;
    }

    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }
        
    public CustomerForView SelectedCustomer
    {
        get => _selectedCustomer;
        set => SetProperty(ref _selectedCustomer, value);
    }

    public ProductTypeForView SelectedProductType
    {
        get => _selectedProductType;
        set => SetProperty(ref _selectedProductType, value);
    }

    public ApplicationStatusForView SelectedApplicationStatus
    {
        get => _selectedApplicationStatus;
        set => SetProperty(ref _selectedApplicationStatus, value);
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


    public override bool ValidateSave()
    {
        return !String.IsNullOrWhiteSpace(Currency)
               && AmountRequested > 0;
    }

    public override CreditApplicationForView SetItem()
    {
        return new CreditApplicationForView()
        {
            CustomerId = SelectedCustomer.Id,
            CustomerFirstName = SelectedCustomer.CustomerFirstName,
            CustomerLastName = SelectedCustomer.CustomerLastName,
            ProductTypeId = SelectedProductType.Id,
            ProductTypeName = SelectedProductType.ProductTypeName,
            ApplicationStatusId = SelectedApplicationStatus.Id,
            ApplicationStatus = SelectedApplicationStatus.ApplicationStatusName,
            Currency = Currency,
            AmountRequested = AmountRequested,
            AmountGranted = AmountGranted,
            DateOfSubmission = DateOfSubmission,
            DateOfLastStatusChange = DateOfLastStatusChange,
            Notes = Notes
        };
    }
}

