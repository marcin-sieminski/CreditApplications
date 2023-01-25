using CreditApplications.Mobile.Models;
using CreditApplications.Mobile.Views;
using Xamarin.Forms;

namespace CreditApplications.Mobile.ViewModels;

public class CustomersViewModel : ItemsViewModel<CustomerForView>
{
    public CustomersViewModel()
        : base("Customers")
    {
    }
    public override async void GoToDetailsPage()
    {
        //await Shell.Current.GoToAsync($"{nameof(CustomerDetailPage)}?{nameof(CustomerDetailViewModel.ItemId)}={item.Id}");
    }

    public override async void GoToAddPage()
    {
        await Shell.Current.GoToAsync(nameof(NewCustomerPage));
    }
}

