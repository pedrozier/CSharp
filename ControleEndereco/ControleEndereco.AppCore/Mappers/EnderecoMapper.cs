using ControleEndereco.AppCore.Commands.AtualizarEndereco;
using ControleEndereco.AppCore.Commands.CriarEndereco;
using ControleEndereco.AppCore.Dtos;
using ControleEndereco.Domain.Entities;

namespace ControleEndereco.AppCore.Mappers
{
    public static class EnderecoMapper
    {
        public static Endereco ToModel(this CriarEnderecoCommand request)
        => new()
        {
            Cep = request.Cep,
            Logradouro = request.Logradouro,
            Complemento = request.Complemento,
            Unidade = request.Unidade,
            Bairro = request.Bairro,
            Localidade = request.Localidade,
            Uf = request.Uf,
            Ibge = request.Ibge,
        };

        public static Endereco ToModel(this AtualizarEnderecoCommand request)
        => new()
        {
            Cep = request.Cep,
            Logradouro = request.Logradouro,
            Complemento = request.Complemento,
            Unidade = request.Unidade,
            Bairro = request.Bairro,
            Localidade = request.Localidade,
            Uf = request.Uf,
            Ibge = request.Ibge,
        };

        public static EnderecoDto ToDto(this Endereco endereco)
            => new()
            {
                Id = endereco.Id,
                Cep = endereco.Cep,
                Logradouro = endereco.Logradouro,
                Complemento = endereco.Complemento,
                Unidade = endereco.Unidade,
                Bairro = endereco.Bairro,
                Localidade = endereco.Localidade,
                Uf = endereco.Uf,
                Ibge = endereco.Ibge
            };

        public static IEnumerable<EnderecoDto> ToDto(this IEnumerable<Endereco> enderecos)
        => enderecos.Select(e => e.ToDto());

    }
}
