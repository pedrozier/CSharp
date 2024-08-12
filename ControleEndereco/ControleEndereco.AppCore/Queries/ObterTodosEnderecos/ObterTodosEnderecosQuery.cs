using ControleEndereco.AppCore.Dtos;

using MediatR;

namespace ControleEndereco.AppCore.Queries.ObterTodosEnderecos
{
    public record ObterTodosEnderecosQuery() : IRequest<IEnumerable<EnderecoDto>>;
}
