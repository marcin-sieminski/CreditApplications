using CreditApplications.Mobile.Models;
using CreditApplications.Mobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CreditApplications.Mobile.ViewModels;

public class CreditApplicationsViewModel : BaseItemsViewModel<CreditApplicationForView>
{
    public CreditApplicationsViewModel()
        : base("Credit applications")
    {
    }

    public override async void GoToDetailsPage(CreditApplicationForView model)
    {
        try
        {
            await Shell.Current.GoToAsync($"{nameof(CreditApplicationDetailPage)}?Id={model.Id}");
        }
        catch (IndexOutOfRangeException ex)
        {

            Log.Warning("Xamarin IndexOutOfRangeException", ex.Message);
        }
    }

    public override async void GoToAddPage()
    {
        await Shell.Current.GoToAsync(nameof(NewCreditApplicationPage));
    }
}

