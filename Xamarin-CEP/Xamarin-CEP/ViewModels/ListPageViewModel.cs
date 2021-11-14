using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_CEP.Models;

namespace Xamarin_CEP.ViewModels
{
    public class ListPageViewModel : BaseViewModel
    {
        public ObservableCollection<Endereço> Endereços { get; }
        public Command LoadEndereçosCommand { get; }

        public ListPageViewModel()
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
                    Endereços.Add(endereço);
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
