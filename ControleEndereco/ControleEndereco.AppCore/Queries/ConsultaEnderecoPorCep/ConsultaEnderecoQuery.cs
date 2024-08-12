using ControleEndereco.AppCore.Dtos;

using MediatR;

namespace ControleEndereco.AppCore.Queries.ConsultaEnderecoPorCep
{
    public record ConsultaEnderecoQuery(string Cep) : IRequest<EnderecoDto>;
}
