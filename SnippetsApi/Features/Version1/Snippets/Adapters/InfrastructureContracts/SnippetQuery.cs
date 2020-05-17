namespace SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts
{
    using Contracts.Models;

    public class SnippetQuery
    {
        public SnippetQuery(
            string snippetId)
        {
            this.SnippetId = snippetId;
        }

        public interface IHandler
        {
            Snippet Handle(
                SnippetQuery query);
        }

        public string SnippetId { get; }
    }
}
