using ConsultaCep.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultaCep.Api.Repository
{
    public interface IRepository<Document> where Document : DocumentBase
    {
        Task<Document> Create(Document document);
        Task<List<Document>> Get();
        Task<Document> Get(string id);
        Task Remove(string id);
        Task<Document> Update(string id, Document document);
    }
}
