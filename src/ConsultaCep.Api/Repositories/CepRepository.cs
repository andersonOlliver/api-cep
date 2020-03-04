using ConsultaCep.Api.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsultaCep.Api.Repository
{
    public class CepRepository : MongoRepository<CepDto>, ICepRepository
    {
        public CepRepository(IConfiguration config)
            : base(config, "Cep")
        {
        }

        public async Task<CepDto> Find(string cep)
        {
            cep = Regex.Replace(cep, @"(\w{5})(\w{3})", @"$1-$2");
            return await _collection.Find(x => string.Equals(x.Cep, cep)).FirstOrDefaultAsync();
        }
    }
}
