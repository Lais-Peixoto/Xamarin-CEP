using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_CEP.Models;
using Xamarin_CEP.Views;

namespace Xamarin_CEP.ViewModels
{
    public class ListPageViewModel : BaseViewModel
    {
        private Endereço seletedAddress;
        public ObservableCollection<Endereço> Endereços { get; }
        public Command LoadEndereçosCommand { get; }
        public Command<Endereço> EndereçoSelecionado { get; }

        public ListPageViewModel()
        {
            Endereços = new ObservableCollection<Endereço>();
            LoadEndereçosCommand = new Command(async () => await ExecuteLoadItemsCommand());
            EndereçoSelecionado = new Command<Endereço>(OnSelectedAddress);
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

        public Endereço SelectedAddress
        {
            get => seletedAddress;
            set
            {
                SetProperty(ref seletedAddress, value);
                OnSelectedAddress(value);
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        async void OnSelectedAddress(Endereço endereço)
        {
            if (endereço == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(EndereçoPage)}?{nameof(EndereçoPageViewModel.CEP)}={endereço.CEP}");
        }

    }
}
