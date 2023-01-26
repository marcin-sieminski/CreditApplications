using CreditApplications.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreditApplications.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerDetailPage : ContentPage
    {
        CustomerDetailViewModel _viewModel;

        public CustomerDetailPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CustomerDetailViewModel();
        }
    }
}