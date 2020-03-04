using ConsultaCep.Api.Models;
using System.Threading.Tasks;

namespace ConsultaCep.Api.Interfaces
{
    public interface IViaCepService
    {
        Task<CepDto> Find(string cep);
    }
}