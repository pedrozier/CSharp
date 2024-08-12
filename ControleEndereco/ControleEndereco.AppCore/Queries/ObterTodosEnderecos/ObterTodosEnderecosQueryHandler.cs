using ControleEndereco.AppCore.Dtos;
using ControleEndereco.AppCore.Mappers;
using ControleEndereco.Domain.Entities;
using ControleEndereco.Domain.Interfaces.Repositories;

using MediatR;

namespace ControleEndereco.AppCore.Queries.ObterTodosEnderecos
{
    public class ObterTodosEnderecosQueryHandler : IRequestHandler<ObterTodosEnderecosQuery, IEnumerable<EnderecoDto>>
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public ObterTodosEnderecosQueryHandler(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<IEnumerable<EnderecoDto>> Handle(ObterTodosEnderecosQuery request, CancellationToken cancellationToken)
        {
            var enderecos = await _enderecoRepository.ObterTodosAsync();
            return enderecos.ToDto();
        }
    }
}
