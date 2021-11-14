using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Xamarin_CEP.ViewModels
{
    [QueryProperty(nameof(CEP), nameof(CEP))]
    public class EndereçoPageViewModel : BaseViewModel
    {
        private string cep;
        private string rua;
        private string bairro;
        private string cidade;

        public string Cep { get; set; }

        public string Rua
        {
            get => rua;
            set => SetProperty(ref rua, value);
        }

        public string Bairro
        {
            get => bairro;
            set => SetProperty(ref bairro, value);
        }

        public string Cidade
        {
            get => cidade;
            set => SetProperty(ref cidade, value);
        }

        public string CEP
        {
            get
            {
                return cep;
            }
            set
            {
                cep = value;
                LoadEndereçoCep(value);
            }
        }

        public async void LoadEndereçoCep(string cep)
        {
            try
            {
                var endereço = await EndereçoContext.Get(cep);
                Rua = endereço.Rua;
                Bairro = endereço.Bairro;
                Cidade = endereço.Cidade;
                Cep = endereço.CEP;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
