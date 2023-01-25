using System;
using System.Collections.Generic;
using System.Text;
using CreditApplications.Mobile.Models;
using CreditApplications.Mobile.Views;
using Xamarin.Forms;

namespace CreditApplications.Mobile.ViewModels;

public class LoginViewModel : BaseViewModel<Item>
{
    public Command LoginCommand { get; }

    public LoginViewModel()
    {
        LoginCommand = new Command(OnLoginClicked);
    }

    private async void OnLoginClicked(object obj)
    {
        // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
    }
}