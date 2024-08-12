using MediatR;

namespace ControleEndereco.AppCore.Commands.CriarEndereco
{
    public record CriarEnderecoCommand(
        string Cep,
        string Logradouro,
        string Complemento,
        string Unidade,
        string Bairro,
        string Localidade,
        string Uf,
        string Ibge
        ) : IRequest<CriarEnderecoResult>;

}
