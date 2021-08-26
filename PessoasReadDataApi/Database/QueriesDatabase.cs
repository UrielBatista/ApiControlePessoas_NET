using Dapper;
using Microsoft.Data.Sqlite;
using PessoasDataApi.Database;
using System.Linq;

namespace SqliteDapper.Demo.Database
{
    public class QueriesDatabase : IQueriesDatabase
    {
        private readonly DatabaseConfig databaseConfig;

        public QueriesDatabase(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'clientes';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "clientes")
                return;


            connection.Execute("Create Table clientes (" +
                "id integer PRIMARY KEY," +
                "nome text," +
                "processo text);");
        }
    }
}
