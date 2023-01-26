using CreditApplications.Mobile.Views;
using System;
using Xamarin.Forms;

namespace CreditApplications.Mobile;

public partial class AppShell : Xamarin.Forms.Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CustomersPage), typeof(CustomersPage));
        Routing.RegisterRoute(nameof(CustomerDetailPage), typeof(CustomerDetailPage));
        Routing.RegisterRoute(nameof(NewCustomerPage), typeof(NewCustomerPage));
        Routing.RegisterRoute(nameof(CustomerEditPage), typeof(CustomerEditPage));
    }

    private async void OnMenuItemClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginPage");
    }
}