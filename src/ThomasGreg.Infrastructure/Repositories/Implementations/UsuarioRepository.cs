using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Domain;
using ThomasGreg.Domain.Interfaces.Repositories;

namespace ThomasGreg.Infrastructure.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _dbConnection;

        public UsuarioRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public async Task<Usuario> ObterUsuarioPorEmailAsync(string email)
        {
            var sql = "SELECT * FROM Usuario WHERE Email = @Email";

            var usuario = await _dbConnection.QueryFirstOrDefaultAsync<Usuario>(sql, new { Email = email });

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            return usuario;
        }
    }
}
