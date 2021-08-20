using Dapper;
using Microsoft.Data.Sqlite;
using PessoasDataApi.Database;
using PessoasDataApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Repository.Support
{
    public class ReturnStatusRepository : IReturnStatusRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public ReturnStatusRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task Create(Cliente product)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            await connection.ExecuteAsync("INSERT INTO clientes (nome, processo)" +
                "VALUES (@Nome, @Processo);", product);
        }
        public async Task Delete()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            await connection.ExecuteAsync("DELETE FROM clientes");
        }
    }
}
