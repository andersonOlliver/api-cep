using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ConsultaCep.Api.Models
{
    public class DocumentBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}
