using ConsultaCep.Api.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaCep.Api.Repository
{

    public class MongoRepository<Document> : IRepository<Document> where Document : DocumentBase
    {
        protected readonly IMongoCollection<Document> _collection;

        public MongoRepository(IConfiguration config, string nameCollection,
            string database = "ConsultaCepDB", string client = "ConsultaCepDB")
        {
            // Connects to MongoDB.
            var _client = new MongoClient(config.GetConnectionString(client));
            // Gets the supplementDB.
            var _database = _client.GetDatabase(database);
            // Fetches the supplement collection.
            _collection = _database.GetCollection<Document>(nameCollection);
        }

        public async Task<List<Document>> Get()
        {
            return await _collection.Find(s => true).ToListAsync();
        }

        public async Task<Document> Get(string id)
        {
            // Get a single document. 
            return await _collection.Find(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Document> Create(Document document)
        {
            document.DataCriacao = DateTime.Now;
            document.UltimaAtualizacao = DateTime.Now;

            // Create a document.
            await _collection.InsertOneAsync(document);
            return document;
        }

        public async Task<Document> Update(string id, Document document)
        {
            document.UltimaAtualizacao = DateTime.Now;
            // Updates and existing document. 
            await _collection.ReplaceOneAsync(su => su.Id == id, document);
            return document;
        }


        public async Task Remove(string id)
        {
            // Removes a document.
            await _collection.DeleteOneAsync(su => su.Id == id);
        }
    }
}
