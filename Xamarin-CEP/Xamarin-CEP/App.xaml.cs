using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_CEP.Models;
using Xamarin_CEP.Services;
using Xamarin_CEP.Views;

namespace Xamarin_CEP
{
    public partial class App : Application
    {
        public static ApplicationContext ApplicationContext;

        public App(string dbPath)
        {
            InitializeComponent();

            Debug.WriteLine($"Banco: {dbPath}");

            ApplicationContext = new ApplicationContext(dbPath);

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
