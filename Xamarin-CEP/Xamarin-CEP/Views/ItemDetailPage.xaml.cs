using System.ComponentModel;
using Xamarin.Forms;
using Xamarin_CEP.ViewModels;

namespace Xamarin_CEP.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}