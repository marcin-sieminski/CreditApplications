using CreditApplications.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreditApplications.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreditApplicationsPage : ContentPage
    {
        CreditApplicationsViewModel _viewModel;
        
        public CreditApplicationsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CreditApplicationsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}