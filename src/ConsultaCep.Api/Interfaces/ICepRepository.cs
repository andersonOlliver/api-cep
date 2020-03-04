using ConsultaCep.Api.Models;
using System.Threading.Tasks;

namespace ConsultaCep.Api.Repository
{
    public interface ICepRepository: IRepository<CepDto>
    {
        Task<CepDto> Find(string cep);
    }
}
