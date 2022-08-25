using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Repository
{
    public interface IDocument
    {
        string Id { get; set; }

        DateTime CreatedAt { get; }
    }
}