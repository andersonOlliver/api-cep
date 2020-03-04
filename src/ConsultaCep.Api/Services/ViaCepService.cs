using ConsultaCep.Api.Interfaces;
using ConsultaCep.Api.Models;
using RestSharp;
using System.Threading.Tasks;

namespace ConsultaCep.Api.Services
{
    public class ViaCepService : IViaCepService
    {
        public async Task<CepDto> Find(string cep)
        {
            var url = $"https://viacep.com.br/ws/";
            var client = new RestClient(url);
            var request = new RestRequest($"{cep}/json/", dataFormat: DataFormat.Json);
            return await client.GetAsync<CepDto>(request);
        }
    }
}
