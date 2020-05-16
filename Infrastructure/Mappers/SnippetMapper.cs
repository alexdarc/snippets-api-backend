namespace Infrastructure.Mappers
{
    using System.Collections.Generic;
    using Contracts.Models;
    using Contracts.Services;
    using MongoDB.Driver;

    public class SnippetMapper
        : ISnippetMapper
    {
        private readonly IMongoCollection<Snippet> snippetsCollection;

        public SnippetMapper(
            MongoCollections mongoCollections)
        {
            this.snippetsCollection = mongoCollections.SnippetsCollection;
        }

        public Snippet Get(
            string id)
        {
            return this.snippetsCollection
                .Find(filter: document => document.Id.ToString() == id)
                .FirstOrDefault();
        }

        public IEnumerable<Snippet> GetMany(
            int limit)
        {
            return this.snippetsCollection
                .Find(filter: document => true)
                .Limit(limit: limit)
                .ToEnumerable();
        }

        public void Insert(
            Snippet snippet)
        {
            this.snippetsCollection
                .InsertOne(document: snippet);
        }

        public void Save(
            Snippet snippet)
        {
            this.snippetsCollection
                .ReplaceOne(
                    filter: document => document.Id == snippet.Id,
                    replacement: snippet);
        }

        public void Remove(
            string id)
        {
            this.snippetsCollection
                .DeleteOne(
                    filter: document => document.Id.ToString() == id);
        }

        public void Remove(
            Snippet snippet)
        {
            this.snippetsCollection
                .DeleteOne(
                    filter: document => document.Id == snippet.Id);
        }
    }
}
