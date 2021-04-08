using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using PessoasDataApi.Models;
using PessoasDataApi.Repository.Support.Scripts;

namespace PessoasDataApi.Repository
{
    public sealed class PessoasRepository : IPessoasRepository
    {
        private readonly string _connectionString;

        public PessoasRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SensorDataServer");
        }

        public async Task<Pessoas[]> ListarPessoasAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = PessoasScripts.SELECT_PESSOAS_DATA;

                var retorno = await connection.QueryAsync<Pessoas>(sql, commandTimeout: 60).ConfigureAwait(false);

                return retorno.ToArray();
            }
        }

        public async Task<PessoasGermany[]> ListarPessoasGermanyAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = PessoasScripts.SELECT_GERMANY_PESSOAS;   

                var retorno = await connection.QueryAsync<PessoasGermany>(sql, commandTimeout: 60).ConfigureAwait(false);

                return retorno.ToArray();
            }
        }

        public async Task<int> InserirPessoasAsync(Pessoas[] step)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = PessoasScripts.INSERT_PESSOAS_DATA;

                return await connection.ExecuteAsync(sql, step, commandTimeout: 60);
            }
            
        }

        public async Task<int> DeletarPessoasAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = PessoasScripts.DELETE_PESSOAS_DATA;

                return await connection.ExecuteAsync(sql: sql, param: new { ID = id }, commandTimeout: 60);
            }
        }

        public async Task<int> DeletarPessoasGermanyAsync(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = PessoasScripts.DELETE_GERMANY_PESSOAS;

                var param = new { iban = id };

                return await connection.ExecuteAsync(sql, param, commandTimeout: 60);
            }
        }

        public async Task<int> AtualizarPessoasAsync(Pessoas[] step)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = PessoasScripts.UPDATE_PESSOAS_DATA;

                return await connection.ExecuteAsync(sql, step, commandTimeout: 60);
            }
        }

        public async Task<int> InserirPessoasGermanyAsync(PessoasGermany data)
        {
            using (var conncetion = new SqlConnection(_connectionString))
            {
                var sql = PessoasScripts.INSERT_GERMANY_PESSOAS;

                return await conncetion.ExecuteAsync(sql, data, commandTimeout: 60);
            }
        }

    }
}

