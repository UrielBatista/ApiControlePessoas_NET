using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Models
{
    public class CreateBotRetornoInput
    {
        public string Nome { get; set; }
        public string Processo { get; set; }
        public int GroupId { get; set; }

    }
}
