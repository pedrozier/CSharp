using ControleEndereco.AppCore.Dtos;
using ControleEndereco.AppCore.Mappers;
using ControleEndereco.Domain.Entities;
using ControleEndereco.Domain.Interfaces.Services;

using MediatR;

namespace ControleEndereco.AppCore.Queries.ConsultaEnderecoPorCep
{
    public class ConsultaEnderecoQueryHandler : IRequestHandler<ConsultaEnderecoQuery, EnderecoDto>
    {
        private readonly IConsultaEnderecoService _consultaEnderecoService;

        public ConsultaEnderecoQueryHandler(IConsultaEnderecoService consultaEnderecoService)
        {
            _consultaEnderecoService = consultaEnderecoService;
        }

        public async Task<EnderecoDto> Handle(ConsultaEnderecoQuery request, CancellationToken cancellationToken)
        {
            Endereco endereco = await _consultaEnderecoService.ObterPorCepAsync(request.Cep);
            return endereco.ToDto();
        }
    }
}
