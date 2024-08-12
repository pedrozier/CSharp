using ControleEndereco.AppCore.Dtos;

using MediatR;

namespace ControleEndereco.AppCore.Queries.ObterEnderecosPorId
{
    public record ObterEnderecoPorIdQuery(long Id) : IRequest<EnderecoDto>;
}
