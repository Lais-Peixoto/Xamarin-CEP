using Xamarin.Forms;
using Xamarin_CEP.Views;

namespace Xamarin_CEP
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(ListPage), typeof(ListPage));
            Routing.RegisterRoute(nameof(EndereçoPage), typeof(EndereçoPage));
            Routing.RegisterRoute(nameof(MapaPage), typeof(MapaPage));
        }

    }
}
