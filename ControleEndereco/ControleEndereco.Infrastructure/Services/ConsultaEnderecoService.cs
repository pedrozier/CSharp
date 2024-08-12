using System.Net.Http.Json;

using ControleEndereco.Domain.Entities;
using ControleEndereco.Domain.Interfaces.Services;
using ControleEndereco.Infrastructure.Models;

namespace ControleEndereco.Infrastructure.Services
{
    public class ConsultaEnderecoService : IConsultaEnderecoService
    {
        private readonly HttpClient _client;

        public ConsultaEnderecoService(HttpClient client)
        {
            _client = client;
        }
        public async ValueTask<Endereco> ObterPorCepAsync(string cep)
        {
            var response = await _client.GetFromJsonAsync<ViaCepResponse>($"https://viacep.com.br/ws/{cep}/json/");
            return new()
            {
                Cep = response.Cep,
                Logradouro = response.Logradouro,
                Complemento = response.Complemento,
                Unidade = response.Unidade,
                Bairro = response.Bairro,
                Localidade = response.Localidade,
                Uf = response.Uf,
                Ibge = response.Ibge,
            };
        }
    }
}
