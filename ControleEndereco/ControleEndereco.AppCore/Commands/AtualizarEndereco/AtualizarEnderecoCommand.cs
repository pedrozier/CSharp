using MediatR;

namespace ControleEndereco.AppCore.Commands.AtualizarEndereco
{
    public record AtualizarEnderecoCommand(
        long Id,
        string Cep,
        string Logradouro,
        string Complemento,
        string Unidade,
        string Bairro,
        string Localidade,
        string Uf,
        string Ibge
        ) : IRequest<AtualizarEnderecoResult>;
}
