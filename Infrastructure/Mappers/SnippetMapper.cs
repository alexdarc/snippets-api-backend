namespace Infrastructure.Mappers
{
    using System.Collections.Generic;
    using Common.Contracts;
    using Common.Mongo;
    using Contracts.Models;
    using Contracts.Services;
    using MongoDB.Bson;
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
                .Find(filter: ById(id: id))
                .FirstOrDefault();
        }

        public IEnumerable<Snippet> GetMany(
            int limit,
            int skip)
        {
            return this.snippetsCollection
                .Find(filter: document => true)
                .Skip(skip: skip)
                .Limit(limit: limit)
                .ToEnumerable();
        }

        public void Insert(
            Snippet snippet)
        {
            this.snippetsCollection
                .InsertOne(document: snippet);
        }

        public void Update(
            string id,
            UpdateInstructions<Snippet> updateInstructions)
        {
            this.snippetsCollection
                .UpdateOne(
                    filter: ById(id: id),
                    update: updateInstructions.ToMongoUpdate());
        }

        public void Remove(
            string id)
        {
            this.snippetsCollection
                .DeleteOne(
                    filter: ById(id: id));
        }

        public void Remove(
            Snippet snippet)
        {
            this.snippetsCollection
                .DeleteOne(
                    filter: ById(snippet: snippet));
        }

        private static FilterDefinition<Snippet> ById(
            string id)
        {
            return Builders<Snippet>.Filter
                .Eq(
                    field: x => x.Id,
                    value: new ObjectId(
                        value: id));
        }

        private static FilterDefinition<Snippet> ById(
            Snippet snippet)
        {
            return Builders<Snippet>.Filter
                .Eq(
                    field: x => x.Id,
                    value: snippet.Id);
        }
    }
}
