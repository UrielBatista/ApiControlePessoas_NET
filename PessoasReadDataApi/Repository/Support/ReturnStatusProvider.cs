using Dapper;
using Microsoft.Data.Sqlite;
using PessoasDataApi.Database;
using PessoasDataApi.Models;
using PessoasDataApi.Repository.Support.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoasDataApi.Repository.Support
{
    public class ReturnStatusProvider : IReturnStatusProvider
    {
        private readonly DatabaseConfig databaseConfig;

        public ReturnStatusProvider(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<Cliente>> Get()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            return await connection.QueryAsync<Cliente>("SELECT rowid AS id, nome, processo FROM clientes;");
        }
    }
}
