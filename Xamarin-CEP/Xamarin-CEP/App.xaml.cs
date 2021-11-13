using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_CEP.Services;
using Xamarin_CEP.Views;

namespace Xamarin_CEP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
