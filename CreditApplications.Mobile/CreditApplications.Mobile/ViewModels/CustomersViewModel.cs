using CreditApplications.Mobile.Models;
using CreditApplications.Mobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CreditApplications.Mobile.ViewModels;

public class CustomersViewModel : BaseItemsViewModel<CustomerForView>
{
    public CustomersViewModel()
        : base("Customers")
    {
    }

    public override async void GoToDetailsPage(CustomerForView model)
    {
        try
        {
            await Shell.Current.GoToAsync($"{nameof(CustomerDetailPage)}?Id={model.Id}");
        }
        catch (IndexOutOfRangeException ex)
        {
            Log.Warning("Xamarin IndexOutOfRangeException", ex.Message);
        }
    }

    public override async void GoToAddPage()
    {
        await Shell.Current.GoToAsync(nameof(NewCustomerPage));
    }
}

