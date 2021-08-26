using PessoasDataApi.Excep;
using PessoasDataApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Services.Support
{
    public class BotRetornoService : IBotRetornoService
    {
        private IList<BotsRetorno> _retornosBots;
        public BotRetornoService()
        {
            _retornosBots = new List<BotsRetorno>()
            {
                new BotsRetorno() { RetornoId = 1, Nome = "Nome 1", Processo = "", GroupId = 1},
                new BotsRetorno() { RetornoId = 2, Nome = "Nome 2", Processo = "", GroupId = 2},
                new BotsRetorno() { RetornoId = 3, Nome = "Nome 3", Processo = "", GroupId = 3},
                new BotsRetorno() { RetornoId = 4, Nome = "Nome 4", Processo = "", GroupId = 4},
            };
        }
        public BotsRetorno Create(CreateBotRetornoInput inpuBotRetorno)
        {
            var retornosBots = new BotsRetorno()
            {
                RetornoId = _retornosBots.Max(x => x.RetornoId) + 1,
                Nome = inpuBotRetorno.Nome,
                Processo = inpuBotRetorno.Processo,
                GroupId = inpuBotRetorno.GroupId
            };
            _retornosBots.Add(retornosBots);
            return retornosBots;
        }

        public BotsRetorno Delete(DeleteBotRetornoInput inpuBotRetorno)
        {
            var retornos = _retornosBots.FirstOrDefault(x => x.RetornoId == inpuBotRetorno.RetornoId);
            if (retornos == null) throw new BotRetornoNotFoundException() { RetornoId = inpuBotRetorno.RetornoId };
            _retornosBots.Remove(retornos);
            return retornos;
        }

        public IQueryable<BotsRetorno> GetAll()
        {
            return _retornosBots.AsQueryable();
        }
    }
}
