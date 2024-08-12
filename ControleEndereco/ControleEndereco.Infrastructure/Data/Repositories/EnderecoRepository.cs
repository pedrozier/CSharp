using ControleEndereco.Domain.Entities;
using ControleEndereco.Domain.Interfaces.Repositories;
using ControleEndereco.Infrastructure.Data.Context;

using Dapper;

namespace ControleEndereco.Infrastructure.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DbSession _session;

        public EnderecoRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<Endereco>> ObterTodosAsync()
        {
            const string sql = @"SELECT ID, CEP, LOGRADOURO, COMPLEMENTO, UNIDADE, BAIRRO, LOCALIDADE, UF, IBGE FROM ENDERECOS";
            return await _session.Connection.QueryAsync<Endereco>(sql, transaction: _session.Transaction);
        }

        public async Task<Endereco> ObterPorIdAsync(long id)
        {
            const string sql = @"SELECT ID, CEP, LOGRADOURO, COMPLEMENTO, UNIDADE, BAIRRO, LOCALIDADE, UF, IBGE FROM ENDERECOS WHERE ID = @Id";
            return await _session.Connection.QuerySingleOrDefaultAsync<Endereco>(sql, new { Id = id }, _session.Transaction);
        }

        public async Task SalvarAsync(Endereco endereco)
        {
            const string sql = @"INSERT INTO ENDERECOS (CEP, LOGRADOURO, COMPLEMENTO, UNIDADE, BAIRRO, LOCALIDADE, UF, IBGE) VALUES (@Cep, @Logradouro, @Complemento, @Unidade, @Bairro, @Localidade, @Uf, @Ibge) RETURNING Id";
            endereco.Id = await _session.Connection.QuerySingleAsync<long>(sql, new
            {
                endereco.Cep,
                endereco.Logradouro,
                endereco.Complemento,
                endereco.Unidade,
                endereco.Bairro,
                endereco.Localidade,
                endereco.Uf,
                endereco.Ibge,
            }, _session.Transaction);
        }

        public async Task AtualizarAsync(long id, Endereco endereco)
        {
            const string sql = @"UPDATE ENDERECOS SET CEP = @Cep, LOGRADOURO = @Logradouro, COMPLEMENTO = @Complemento, UNIDADE = @Unidade, BAIRRO = @Bairro, LOCALIDADE = @Localidade, UF = @Uf, IBGE = @Ibge WHERE ID = @Id";
            await _session.Connection.ExecuteAsync(sql, new
            {
                endereco.Cep,
                endereco.Logradouro,
                endereco.Complemento,
                endereco.Unidade,
                endereco.Bairro,
                endereco.Localidade,
                endereco.Uf,
                endereco.Ibge,
                Id = id
            }, _session.Transaction);
        }

        public async Task DeletarAsync(long id)
        {
            const string sql = @"DELETE FROM ENDERECOS WHERE ID = @Id";
            await _session.Connection.ExecuteAsync(sql, new { Id = id }, _session.Transaction);
        }
    }
}
