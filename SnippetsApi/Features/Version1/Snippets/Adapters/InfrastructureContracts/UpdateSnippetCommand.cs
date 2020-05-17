namespace SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts
{
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class UpdateSnippetCommand
    {
        public UpdateSnippetCommand(
            string snippetId,
            SnippetModel snippetModel)
        {
            this.SnippetId = snippetId;
            this.SnippetModel = snippetModel;
        }

        public interface IHandler
        {
            void Handle(
                UpdateSnippetCommand command);
        }

        public string SnippetId { get; }

        public SnippetModel SnippetModel { get; }
    }
}
