using CreditApplications.Mobile.Views;
using Xamarin.Forms;

namespace CreditApplications.Mobile.ViewModels;

public abstract class BaseItemEditViewModel<T> : BaseViewModel<T>
{
    public BaseItemEditViewModel(string title)
    {
        Title = title;
        CancelCommand = new Command(OnCancel);
        SaveCommand = new Command(OnSave, ValidateSave);
        CancelCommand = new Command(OnCancel);
        this.PropertyChanged +=
            (_, __) => SaveCommand.ChangeCanExecute();
    }

    public Command CancelCommand { get; }
    public abstract bool ValidateSave();
    public Command SaveCommand { get; }

    private async void OnSave()
    {
        await DataStore.UpdateItemAsync(SetItem());
        await Shell.Current.GoToAsync("../..");
    }
    public abstract T SetItem();


    private async void OnCancel()
    {
        await Shell.Current.GoToAsync("../..");
    }

    public void OnAppearing()
    {
        IsBusy = true;
    }
}

