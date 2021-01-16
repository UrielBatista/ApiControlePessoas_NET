using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Domain
{
    public sealed class Pessoas
    {
        public long ID { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public int idade { get; set; }
        public string enderesso { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
    }
}
