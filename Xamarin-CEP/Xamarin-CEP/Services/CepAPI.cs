using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin_CEP.Models;

namespace Xamarin_CEP.Services
{
    public class CepAPI
    {
        const string Url = "viacep.com.br/ws";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            return client;
        }

        public async Task<Cep> GetCep(int cep)
        {
            var client = GetClient();

            var queryString = $"{Url}/{cep}/json";

            var response = await client.GetAsync(queryString);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Cep>(content);
            }

            return new Cep();
        }
    }
}
