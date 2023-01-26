using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditApplications.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreditApplications.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerEditPage : ContentPage
    {
        CustomerEditViewModel _viewModel;

        public CustomerEditPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CustomerEditViewModel();
        }
    }
}