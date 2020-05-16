namespace SnippetsApi.Features.Version1.Snippets.Models
{
    public class SnippetModel
    {
        public SnippetModel(
            string id,
            string description,
            string content)
        {
            this.Id = id;
            this.Description = description;
            this.Content = content;
        }

        public string Id { get; }

        public string Description { get; }

        public string Content { get; }
    }
}
