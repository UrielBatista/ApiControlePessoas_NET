using PessoasDataApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Services
{
    public interface IPessoasService
    {

        Task<Pessoas[]> ListarPessoasAsync();

        Task<PessoasGermany[]> ListarPessoasGermanyAsync();

        Task<int> InserirPessoasAsync(Pessoas[] step);

        Task<string> ExecutorBot(Bot data);

        Task<string> ListaRetornoBotsAsync();

        Task<string> RetornoBotExecutorAsync(ReceiveBot data);

        Task<int> DeletarPessoasAsync(int id);

        Task<int> DeletarPessoasGermanyAsync(string id);

        Task<int> AtualizarPessoasAsync(Pessoas[] step);
        
    }
}
