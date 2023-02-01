using CreditApplications.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreditApplications.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        private AboutViewModel _viewModel;
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AboutViewModel();
        }
    }
}