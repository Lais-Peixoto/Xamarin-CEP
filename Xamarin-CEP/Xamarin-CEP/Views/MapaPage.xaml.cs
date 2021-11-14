
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_CEP.ViewModels;

namespace Xamarin_CEP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapaPage : ContentPage
    {
        MapaPageViewModel viewModel;

        public MapaPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MapaPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}