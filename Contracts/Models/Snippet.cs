namespace Contracts.Models
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Snippet
    {
        public Snippet(
            string description,
            string content,
            DateTime createdDate,
            DateTime updatedDate)
        {
            this.Description = description;
            this.Content = content;
            this.CreatedDate = createdDate;
            this.UpdatedDate = updatedDate;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
