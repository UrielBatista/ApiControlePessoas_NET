using Microsoft.EntityFrameworkCore;
using PessoasDataApi.Models;


namespace PessoasDataApi.Repository
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public Contexto(DbContextOptions<Contexto> options)
           : base(options)
        { }
    }
}
