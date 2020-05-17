namespace Common.Mongo
{
    using System.Linq;
    using Common.Contracts;
    using MongoDB.Driver;

    public static class UpdateInstructionsExtensions
    {
        public static UpdateDefinition<T> ToMongoUpdate<T>(
            this UpdateInstructions<T> updateInstructions)
        {
            return Builders<T>.Update.Combine(
                updates: updateInstructions.SetOperations
                    .Select(
                        selector: x => Builders<T>.Update.Set(
                            field: x.Key,
                            value: x.Value)));
        }
    }
}
