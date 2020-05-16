namespace SnippetsApi
{
    using MongoDB.Driver;

    public static class MongoFactory
    {
        public static IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(
                connectionString: "mongodb+srv://account-user:8urlmCHi7xQ1jIbc@cluster0-wkdn1.mongodb.net/test?retryWrites=true&w=majority"
            );

            return client.GetDatabase(name: "SnippetsDb");
        }
    }
}
