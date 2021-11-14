using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_CEP.Models
{
    public class Endereço
    {
        public Guid Id { get; set; }

        public string Rua { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }
    }
}
