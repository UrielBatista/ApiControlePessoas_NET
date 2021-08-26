using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Models
{
    public class BotsRetorno
    {
        public int RetornoId { get; set; }
        public string Nome { get; set; }
        public string Processo { get; set; }
        public int GroupId { get; set; }
    }
}
