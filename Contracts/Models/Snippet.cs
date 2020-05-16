namespace Contracts.Models
{
    using System;

    public class Snippet
    {
        public Snippet(
            string id,
            string description,
            string content,
            DateTime createdDate,
            DateTime updatedDate)
        {
            this.Id = id;
            this.Description = description;
            this.Content = content;
            this.CreatedDate = createdDate;
            this.UpdatedDate = updatedDate;
        }

        public string Id { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
