using System.Diagnostics;
using Xamarin.Forms;
using Xamarin_CEP.Models;

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
