using CreditApplications.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreditApplications.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreditApplicationEditPage : ContentPage
    {
        CreditApplicationEditViewModel _viewModel;

        public CreditApplicationEditPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CreditApplicationEditViewModel();
        }
    }
}