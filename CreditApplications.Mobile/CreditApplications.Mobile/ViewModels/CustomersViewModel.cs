using CreditApplications.Mobile.Models;
using CreditApplications.Mobile.Views;
using Xamarin.Forms;

namespace CreditApplications.Mobile.ViewModels;

public class CustomersViewModel : BaseItemsViewModel<CustomerForView>
{
    public CustomersViewModel()
        : base("Customers")
    {
    }

    public override async void GoToDetailsPage(CustomerForView model)
    {
        await Shell.Current.GoToAsync($"{nameof(CustomerDetailPage)}?Id={model.Id}");
    }

    public override async void GoToAddPage()
    {
        await Shell.Current.GoToAsync(nameof(NewCustomerPage));
    }
}

