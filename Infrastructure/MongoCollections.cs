namespace Infrastructure
{
    using Contracts.Models;
    using MongoDB.Driver;

    public class MongoCollections
    {
        private readonly IMongoDatabase database;

        public MongoCollections(
            IMongoDatabase database)
        {
            this.database = database;
        }

        public IMongoCollection<Snippet> SnippetsCollection => this.database.GetCollection<Snippet>(
            name: "Snippets");
    }
}
