using CreditApplications.Mobile.Services;
using CreditApplications.Mobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreditApplications.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            
            DependencyService.Register<CustomerDataStore>();
            DependencyService.Register<CreditApplicationDataStore>();
            DependencyService.Register<ApplicationStatusDataStore>();
            DependencyService.Register<ProductTypeDataStore>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
