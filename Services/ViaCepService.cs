using DataBridge.Models;
using System.Text.Json;

namespace DataBridge.Services
{
    public class ViaCepService
    {
         private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
        }

        public async Task<EnderecoViaCep?> BuscarEnderecoPorCepAsync(string cep)
        {
            cep = cep.Replace("-", "").Trim();

            if (cep.Length != 8)
                return null;

            var url = $"https://viacep.com.br/ws/{cep}/json/";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var endereco = JsonSerializer.Deserialize<EnderecoViaCep>(json, options);

            if (endereco != null && endereco.Erro)
                return null;

            return endereco;
        }
    }
}
