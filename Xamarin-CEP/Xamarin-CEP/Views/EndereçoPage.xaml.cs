using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_CEP.ViewModels;

namespace Xamarin_CEP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EndereçoPage : ContentPage
    {
        public EndereçoPage()
        {
            InitializeComponent();
            BindingContext = new EndereçoPageViewModel();
        }
    }
}