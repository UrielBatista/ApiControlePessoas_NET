using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Processo { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
