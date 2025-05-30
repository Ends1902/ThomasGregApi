using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Domain;


namespace ThomasGreg.Infrastructure.Repositories.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection _dbConnection;

        public ClienteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Inserir Cliente
        public async Task InserirClienteComLogradourosAsync(Cliente cliente)
        {
            if (_dbConnection.State != ConnectionState.Open)
                 _dbConnection.Open();

            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    // Inserir Cliente
                    var sqlCliente = "sp_InserirCliente";
                    var parametersCliente = new
                    {
                        cliente.Nome,
                        cliente.Email,
                        cliente.Logotipo
                    };

                    await _dbConnection.ExecuteAsync(
                        sqlCliente,
                        parametersCliente,
                        transaction: transaction,
                        commandType: CommandType.StoredProcedure
                    );

                    // Inserir Logradouros
                    var sqlLogradouro = "sp_InserirLogradouro";

                    foreach (var logradouro in cliente.Logradouros)
                    {
                        var parametersLogradouro = new
                        {
                            logradouro.Nome,
                            logradouro.Numero,
                            logradouro.Cep,
                            Email = cliente.Email
                        };

                        await _dbConnection.ExecuteAsync(
                            sqlLogradouro,
                            parametersLogradouro,
                            transaction: transaction,
                            commandType: CommandType.StoredProcedure
                        );
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao inserir cliente com logradouros", ex);
                }
            }

            _dbConnection.Close();
        }

        // Atualizar Cliente
        public async Task AtualizarClienteAsync(Cliente cliente)
        {
            var sql = "sp_AtualizarCliente";
            var parameters = new { cliente.Nome, cliente.Logotipo, cliente.Email };
            await _dbConnection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
        }

        // Remover Cliente (e seus logradouros)
        public async Task RemoverClienteAsync(string email)
        {
            var sql = "sp_RemoverCliente";
            var parameters = new { Email = email };
            await _dbConnection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<Cliente> ObterClienteComLogradourosAsync(string email)
        {
            var sql = "sp_ObterClienteComLogradouros";
            var parameters = new { Email = email };

            using var multi = await _dbConnection.QueryMultipleAsync(
                sql,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            var cliente = await multi.ReadFirstOrDefaultAsync<Cliente>();

            if (cliente == null)
                throw new Exception("Cliente não encontrado.");

            var logradouros = (await multi.ReadAsync<Logradouro>()).ToList();

            cliente.Logradouros = logradouros;

            return cliente;
        }

    }
}


