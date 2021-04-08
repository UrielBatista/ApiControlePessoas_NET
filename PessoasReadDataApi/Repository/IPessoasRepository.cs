using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PessoasDataApi.Models;

namespace PessoasDataApi.Repository
{
    public interface IPessoasRepository
    {

        Task<int> InserirPessoasAsync(Pessoas[] step);

        Task<int> InserirPessoasGermanyAsync(PessoasGermany data);

        Task<Pessoas[]> ListarPessoasAsync();

        Task<PessoasGermany[]> ListarPessoasGermanyAsync();

        Task<int> DeletarPessoasAsync(int id);

        Task<int> DeletarPessoasGermanyAsync(string id);

        Task<int> AtualizarPessoasAsync(Pessoas[] step);
    }
}
