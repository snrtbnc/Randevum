using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Repository
{
    public class Document : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime CreatedAt => ObjectId.Parse(Id).CreationTime;
    }
}