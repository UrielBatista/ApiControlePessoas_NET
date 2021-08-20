using PessoasDataApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Repository
{
    public interface IReturnStatusProvider
    {
        Task<IEnumerable<Cliente>> Get();
    }
}
