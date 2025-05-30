using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace ThomasGreg.API.ScriptsIniciais.Servicos
{
    public class DatabaseInitializer
    {
        private readonly IConfiguration _config;

        public DatabaseInitializer(IConfiguration config)
        {
            _config = config;
        }

        public async Task InitializeAsync()
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");

            // Usa caminho absoluto baseado no diretório da aplicação
            var path = Path.Combine(AppContext.BaseDirectory, "ScriptsIniciais", "Scripts", "Init.sql");
            var script = File.ReadAllText(path);

            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();

            using var command = new SqlCommand(script, conn);
            await command.ExecuteNonQueryAsync();
        }
    }
}
