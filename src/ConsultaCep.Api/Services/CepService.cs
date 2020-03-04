using ConsultaCep.Api.Interfaces;
using ConsultaCep.Api.Models;
using ConsultaCep.Api.Repository;
using System;
using System.Threading.Tasks;

namespace ConsultaCep.Api.Services
{
    public class CepService : ICepService
    {
        private readonly ICepRepository _repository;
        private readonly IViaCepService _viaCepService;

        public CepService(ICepRepository repository, IViaCepService viaCepService)
        {
            _repository = repository;
            _viaCepService = viaCepService;
        }

        public async Task<CepDto> FindAsync(string cep)
        {

            var resultDb = await _repository.Find(cep);

            if (resultDb != null)
            {
                return resultDb;
            }

            var resultExternal = await FindExternal(cep);

            if(resultExternal != null)
            {
                return await _repository.Create(resultExternal);
            }

            throw new Exception("Nenhum cep encontrado");
        }

        private async Task<CepDto> FindExternal(string cep)
        {
            return await _viaCepService.Find(cep);
        }
    }
}
