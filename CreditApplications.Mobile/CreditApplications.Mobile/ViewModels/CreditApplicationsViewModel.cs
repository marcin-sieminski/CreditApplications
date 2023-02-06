using CreditApplications.Mobile.Models;
using CreditApplications.Mobile.Views;
using Xamarin.Forms;

namespace CreditApplications.Mobile.ViewModels;

public class CreditApplicationsViewModel : BaseItemsViewModel<CreditApplicationForView>
{
    public CreditApplicationsViewModel()
        : base("Credit applications")
    {
    }

    public override async void GoToDetailsPage(CreditApplicationForView model)
    {
        //await Shell.Current.GoToAsync($"{nameof(CreditApplicationDetailPage)}?Id={model.Id}");
    }

    public override async void GoToAddPage()
    {
        //await Shell.Current.GoToAsync(nameof(NewCreditApplicationPage));
    }
}

