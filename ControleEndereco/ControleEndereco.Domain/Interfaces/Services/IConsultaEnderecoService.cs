using ControleEndereco.Domain.Entities;

namespace ControleEndereco.Domain.Interfaces.Services
{
    public interface IConsultaEnderecoService
    {
        ValueTask<Endereco> ObterPorCepAsync(string cep);
    }
}
