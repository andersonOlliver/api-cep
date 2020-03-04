using ConsultaCep.Api.Models;
using System.Threading.Tasks;

namespace ConsultaCep.Api.Interfaces
{
    public interface ICepService
    {
        Task<CepDto> FindAsync(string cep);
    }
}