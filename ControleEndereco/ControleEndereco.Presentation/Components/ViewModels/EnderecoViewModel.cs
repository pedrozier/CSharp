using ControleEndereco.AppCore.Commands.AtualizarEndereco;
using ControleEndereco.AppCore.Commands.CriarEndereco;
using ControleEndereco.AppCore.Commands.DeletarEndereco;
using ControleEndereco.AppCore.Queries;
using ControleEndereco.AppCore.Queries.ConsultaEnderecoPorCep;
using ControleEndereco.AppCore.Queries.ObterEnderecosPorId;
using ControleEndereco.AppCore.Queries.ObterTodosEnderecos;
using ControleEndereco.Presentation.Components.Models;

using MediatR;

namespace ControleEndereco.Presentation.Components.ViewModels
{
    public class EnderecoViewModel
    {
        private readonly IMediator _mediator;

        public List<Endereco> Enderecos { get; private set; } = new List<Endereco>();

        public EnderecoViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task CarregarEnderecosAsync()
        {
            var enderecosDto = await _mediator.Send(new ObterTodosEnderecosQuery());

            Enderecos = enderecosDto.Select(e => new Endereco
            {
                Id = e.Id,
                Cep = e.Cep,
                Logradouro = e.Logradouro,
                Complemento = e.Complemento,
                Unidade = e.Unidade,
                Bairro = e.Bairro,
                Localidade = e.Localidade,
                Uf = e.Uf,
                Ibge = e.Ibge
            }).ToList();
        }

        public async Task<Endereco> ObterEnderecoPorIdAsync(long id)
        {
            var enderecoDto = await _mediator.Send(new ObterEnderecoPorIdQuery(id));
            if (enderecoDto != null)
            {
                return new Endereco
                {
                    Id = enderecoDto.Id,
                    Cep = enderecoDto.Cep,
                    Logradouro = enderecoDto.Logradouro,
                    Complemento = enderecoDto.Complemento,
                    Unidade = enderecoDto.Unidade,
                    Bairro = enderecoDto.Bairro,
                    Localidade = enderecoDto.Localidade,
                    Uf = enderecoDto.Uf,
                    Ibge = enderecoDto.Ibge
                };
            }
            return null;
        }

        public async Task<Endereco> ConsultarEnderecoPorCepAsync(string cep)
        {
            var enderecoDto = await _mediator.Send(new ConsultaEnderecoQuery(cep));
            if (enderecoDto != null)
            {
                return new Endereco
                {
                    Id = enderecoDto.Id,
                    Cep = enderecoDto.Cep,
                    Logradouro = enderecoDto.Logradouro,
                    Complemento = enderecoDto.Complemento,
                    Unidade = enderecoDto.Unidade,
                    Bairro = enderecoDto.Bairro,
                    Localidade = enderecoDto.Localidade,
                    Uf = enderecoDto.Uf,
                    Ibge = enderecoDto.Ibge
                };
            }
            return null;
        }

        public async Task<bool> CriarEnderecoAsync(Endereco endereco)
        {
            var command = new CriarEnderecoCommand(
                endereco.Cep,
                endereco.Logradouro,
                endereco.Complemento,
                endereco.Unidade,
                endereco.Bairro,
                endereco.Localidade,
                endereco.Uf,
                endereco.Ibge
            );

            var result = await _mediator.Send(command);
            return result.Id.HasValue;
        }

        public async Task<bool> AtualizarEnderecoAsync(Endereco endereco)
        {
            var command = new AtualizarEnderecoCommand(
                endereco.Id,
                endereco.Cep,
                endereco.Logradouro,
                endereco.Complemento,
                endereco.Unidade,
                endereco.Bairro,
                endereco.Localidade,
                endereco.Uf,
                endereco.Ibge
            );

            var result = await _mediator.Send(command);
            return result.Id.HasValue;
        }

        public async Task<bool> DeletarEnderecoAsync(long id)
        {
            var command = new DeletarEnderecoCommand(id);
            var result = await _mediator.Send(command);
            return result.complete.GetValueOrDefault(false);
        }
    }
}
