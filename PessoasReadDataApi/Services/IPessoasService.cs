using PessoasDataApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Services
{
    public interface IPessoasService
    {
        Task<Pessoas[]> ListarPessoasAsync();

        Task<int> InserirPessoasAsync(Pessoas[] step);
    }
}
