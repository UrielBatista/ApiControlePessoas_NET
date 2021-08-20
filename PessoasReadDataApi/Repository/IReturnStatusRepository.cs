using PessoasDataApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Repository
{
    public interface IReturnStatusRepository
    {
        Task Create(Cliente product);

        Task Delete();
    
    }
}
