using ControleEndereco.Domain.Entities;

namespace ControleEndereco.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> ObterTodosAsync();
        Task<Endereco> ObterPorIdAsync(long id);
        Task SalvarAsync(Endereco endereco);
        Task AtualizarAsync(long id, Endereco endereco);
        Task DeletarAsync(long id);
    }
}
