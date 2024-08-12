using ControleEndereco.AppCore.Dtos;
using ControleEndereco.AppCore.Queries.ObterEnderecosPorId;
using ControleEndereco.Domain.Interfaces.Repositories;

using ControleEndereco.AppCore.Mappers;

using MediatR;
using ControleEndereco.Domain.Entities;

namespace ControleEndereco.AppCore.Queries.ObterEnderecoPorId
{
    public class ObterEnderecoPorIdQueryHandler : IRequestHandler<ObterEnderecoPorIdQuery, EnderecoDto>
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public ObterEnderecoPorIdQueryHandler(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<EnderecoDto> Handle(ObterEnderecoPorIdQuery request, CancellationToken cancellationToken)
        {
            Endereco endereco = await _enderecoRepository.ObterPorIdAsync(request.Id);
            return endereco.ToDto();
        }
    }
}
