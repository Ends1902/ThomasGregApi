using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ThomasGreg.Domain;


namespace ThomasGreg.Infrastructure.Repositories
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private readonly IDbConnection _dbConnection;

        public LogradouroRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Inserir Logradouro
        public async Task InserirLogradouroAsync(Logradouro logradouro)
        {
            var sql = "sp_InserirLogradouro";
            var parameters = new { logradouro.Nome, logradouro.Numero, logradouro.Cep };
            await _dbConnection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
        }

        // Atualizar Logradouro
        public async Task AtualizarLogradouroAsync(Logradouro logradouro)
        {
            var sql = "sp_AtualizarLogradouro";
            var parameters = new { logradouro.Id, logradouro.Nome, logradouro.Numero, logradouro.Cep };
            await _dbConnection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
        }

        // Remover Logradouro
        public async Task RemoverLogradouroAsync(int logradouroId)
        {
            var sql = "sp_RemoverLogradouro";
            var parameters = new { Id = logradouroId };
            await _dbConnection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Logradouro>> ListarLogradourosAsync()
        {
            var sql = "sp_ListarLogradouros";
            var logradouros = await _dbConnection.QueryAsync<Logradouro>(
                sql,
                commandType: CommandType.StoredProcedure);

            return logradouros;
        }
    }
}