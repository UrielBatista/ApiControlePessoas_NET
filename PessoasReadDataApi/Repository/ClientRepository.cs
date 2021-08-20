using Microsoft.EntityFrameworkCore;
using PessoasDataApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Repository
{

    public interface IClienteRepository
    {
        List<Cliente> Listar();
        Cliente Selecionar(int id);
        int Excluir(int id);
    }

    public class ClientRepository : IClienteRepository
    {
        private readonly Contexto _contexto;

        public ClientRepository(Contexto contexto_)
        {
            _contexto = contexto_;
        }

        public int Excluir(int id)
        {
            _contexto.Remove(_contexto.Clientes.Find(id));
            return _contexto.SaveChanges();
        }

        public List<Cliente> Listar() => _contexto.Clientes.AsTracking().ToList();

        public Cliente Selecionar(int id) => _contexto.Clientes.FirstOrDefault(p => p.Id == id);
    }
}
