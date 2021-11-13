
using Xamarin.Forms;
using Xamarin_CEP.ViewModels;

namespace Xamarin_CEP.Views
{
    public partial class HomePage : ContentPage
    {
        HomePageViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new HomePageViewModel();
        }
    }
}