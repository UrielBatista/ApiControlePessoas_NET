using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Models
{
    public sealed class PessoasGermany
    {
        public string nomes { get; set; }
        public string enderessos { get; set; }
        public string cidade { get; set; }
        public string codigoPostal { get; set; }
        public string iban { get; set; }
    }
}
