using Xamarin.Forms;

namespace CreditApplications.Mobile.ViewModels;

public abstract class BaseItemDetailViewModel<T> : BaseViewModel<T>
{
    public BaseItemDetailViewModel(string title)
    {
        Title = title;
        CancelCommand = new Command(OnCancel);
        EditCommand = new Command(OnEdit);
        DeleteCommand = new Command(OnDelete);
    }

    public Command CancelCommand { get; }
    public Command EditCommand { get; }
    public Command DeleteCommand { get; }


    private async void OnCancel()
    {
        await Shell.Current.GoToAsync("..");
    }

    void OnEdit()
    {
        GoToEditPage();
    }
    async void OnDelete()
    {
        await DataStore.DeleteItemAsync(GetIdToDelete());
        await Shell.Current.GoToAsync("..");
    }

    public abstract int GetIdToDelete();

    public abstract void GoToEditPage();

    public void OnAppearing()
    {
        IsBusy = true;
    }
}

