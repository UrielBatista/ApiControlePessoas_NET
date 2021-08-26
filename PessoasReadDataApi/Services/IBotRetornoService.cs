using PessoasDataApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Services
{
    public interface IBotRetornoService
    {
        IQueryable<BotsRetorno> GetAll();
        BotsRetorno Create(CreateBotRetornoInput inpuBotRetorno);
        BotsRetorno Delete(DeleteBotRetornoInput inpuBotRetorno);
    }
}
