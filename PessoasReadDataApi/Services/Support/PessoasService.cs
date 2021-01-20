using PessoasDataApi.Domain;
using PessoasDataApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Services.Support
{
    public class PessoasService : IPessoasService
    {
        private readonly IPessoasRepository _pessoasRepository;

        public PessoasService(IPessoasRepository pessoasRepository)
        {
            this._pessoasRepository = pessoasRepository;
        }

        public async Task<int> InserirPessoasAsync(Pessoas[] step)
        {
            var retorno = await _pessoasRepository.InserirPessoasAsync(step);

            return retorno;
        }

        public async Task<Pessoas[]> ListarPessoasAsync()
        {
            var retorno = await _pessoasRepository.ListarPessoasAsync();

            return retorno;
        }

        public async Task<int> DeletarPessoasAsync(int id)
        {
            var retorno = await _pessoasRepository.DeletarPessoasAsync(id);

            return retorno;
        }

        public async Task<int> AtualizarPessoasAsync(Pessoas[] step)
        {
            var retorno = await _pessoasRepository.AtualizarPessoasAsync(step);

            return retorno;
        }
    }
}
