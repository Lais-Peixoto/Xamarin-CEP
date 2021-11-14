﻿using System;
using Xamarin.Forms;
using Xamarin_CEP.Models;
using Xamarin_CEP.Services;

namespace Xamarin_CEP.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private string entryCep;

        private bool isVisible;

        private string bairro;

        private string cidade;

        private string logradouro;

        private CepAPI api { get; set; }

        public string EntryCep {
            get => entryCep;
            set => SetProperty(ref entryCep, value);
        }

        public bool IsVisible {
            get => isVisible;
            set => SetProperty(ref isVisible, value);
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

        public string Logradouro
        {
            get => logradouro;
            set => SetProperty(ref logradouro, value);
        }

        public Command SearchCommand { get; }
        public Command SaveCommand { get; }

        public HomePageViewModel()
        {
            api = new CepAPI();

            IsVisible = false;

            SearchCommand = new Command(ExecuteSearchCommand, ValidateEntry);
            SaveCommand = new Command(OnSave);
            this.PropertyChanged +=
                (_, __) => SearchCommand.ChangeCanExecute();
        }

        private bool ValidateEntry()
        {
            return !String.IsNullOrWhiteSpace(entryCep) && entryCep.Length == 8;
        }

        private async void ExecuteSearchCommand()
        {
            IsVisible = true;

            var response = await api.GetCep(EntryCep);

            Bairro = response.Bairro;
            Cidade = response.Localidade;
            Logradouro = response.Logradouro;

        }

        private async void OnSave()
        {
            Endereço novoEndereço = new Endereço()
            {
                Id = Guid.NewGuid(),
                Rua = Logradouro,
                Bairro = Bairro,
                Cidade = Cidade,
                CEP = EntryCep
            };

            await EndereçoContext.Add(novoEndereço);

        }

    }
}
