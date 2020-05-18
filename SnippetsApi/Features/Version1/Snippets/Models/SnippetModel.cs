namespace SnippetsApi.Features.Version1.Snippets.Models
{
    using System;

    public class SnippetModel
    {
        public SnippetModel(
            string id,
            string description,
            string content,
            DateTime createDate,
            DateTime lastUpdateDate)
        {
            this.Id = id;
            this.Description = description;
            this.Content = content;
            this.CreateDate = createDate;
            this.LastUpdateDate = lastUpdateDate;
        }

        public string Id { get; }

        public string Description { get; }

        public string Content { get; }

        public DateTime CreateDate { get; }

        public DateTime LastUpdateDate { get; }
    }
}
