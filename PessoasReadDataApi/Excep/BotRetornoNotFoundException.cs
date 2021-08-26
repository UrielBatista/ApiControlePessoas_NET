using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Excep
{
    public class BotRetornoNotFoundException : Exception
    {
        public int RetornoId { get; internal set; }
    }
}
