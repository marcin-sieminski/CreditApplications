using System;
using System.Linq;
using CreditApplications.Mobile.Models;
using Xamarin.Forms;

namespace CreditApplications.Mobile.ViewModels;

public abstract class BaseNewItemViewModel<T> : BaseViewModel<T>
{
    public BaseNewItemViewModel()
    {
        SaveCommand = new Command(OnSave, ValidateSave);
        CancelCommand = new Command(OnCancel);
        this.PropertyChanged +=
            (_, __) => SaveCommand.ChangeCanExecute();
    }

    public abstract bool ValidateSave();
    public Command SaveCommand { get; }
    public Command CancelCommand { get; }

    private async void OnCancel()
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnSave()
    {
        await DataStore.AddItemAsync(SetItem());
        await Shell.Current.GoToAsync("..");
    }
    public abstract T SetItem();

}