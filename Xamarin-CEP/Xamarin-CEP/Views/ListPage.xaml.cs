
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_CEP.ViewModels;

namespace Xamarin_CEP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        ListPageViewModel viewModel;

        public ListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ListPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}