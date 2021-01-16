using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PessoasDataApi.Domain;

namespace PessoasDataApi.Repository
{
    public interface IPessoasRepository
    {
        Task<int> InserirPessoasAsync(Pessoas[] step);

        Task<Pessoas[]> ListarPessoasAsync();
        
    }
}
