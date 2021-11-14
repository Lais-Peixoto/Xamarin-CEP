using Plugin.ExternalMaps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_CEP.Models;

namespace Xamarin_CEP.ViewModels
{
    public class MapaPageViewModel : BaseViewModel
    {
        private string cep;

        public ObservableCollection<Endereço> Endereços { get; }

        public Command LoadEndereçosCommand { get; }

        public MapaPageViewModel()
        {
            Endereços = new ObservableCollection<Endereço>();
            LoadEndereçosCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Endereços.Clear();
                var endereços = await EndereçoContext.List(true);
                foreach (var endereço in endereços)
                {
                    await CrossExternalMaps.Current.NavigateTo("Teste", endereço.Rua, endereço.Cidade, "RJ", endereço.CEP, "BR", "55");

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
