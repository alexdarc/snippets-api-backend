namespace SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts
{
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class CreateSnippetQuery
    {
        public CreateSnippetQuery(
            string description,
            string content)
        {
            this.Description = description;
            this.Content = content;
        }

        public interface IHandler
        {
            SnippetModel Handle(
                CreateSnippetQuery query);
        }

        public string Description { get; }

        public string Content { get; }
    }
}
