﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Models
{
    public sealed class Pessoas
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public int idade { get; set; }
        public string enderesso { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
    }
}
