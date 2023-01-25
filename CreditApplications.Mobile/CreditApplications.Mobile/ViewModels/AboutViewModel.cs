using System.Windows.Input;
using CreditApplications.Mobile.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CreditApplications.Mobile.ViewModels;

public class AboutViewModel : BaseViewModel<Item>
{
    public AboutViewModel()
    {
        Title = "About";
        OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
    }

    public ICommand OpenWebCommand { get; }
}