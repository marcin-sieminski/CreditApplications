using CreditApplications.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreditApplications.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreditApplicationDetailPage : ContentPage
    {
        CreditApplicationDetailViewModel _viewModel;

        public CreditApplicationDetailPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CreditApplicationDetailViewModel();
        }
    }
}