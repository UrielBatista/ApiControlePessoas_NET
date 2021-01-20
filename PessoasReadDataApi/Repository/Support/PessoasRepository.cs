using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using PessoasDataApi.Domain;
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

        public async Task<int> AtualizarPessoasAsync(Pessoas[] step)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = PessoasScripts.UPDATE_PESSOAS_DATA;

                return await connection.ExecuteAsync(sql, step, commandTimeout: 60);
            }
        }
    }
}

