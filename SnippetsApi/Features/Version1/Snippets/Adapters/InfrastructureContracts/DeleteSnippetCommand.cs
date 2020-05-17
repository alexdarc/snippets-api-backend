namespace SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts
{
    public class DeleteSnippetCommand
    {
        public DeleteSnippetCommand(
            string snippetId)
        {
            this.SnippetId = snippetId;
        }

        public interface IHandler
        {
            void Handle(
                DeleteSnippetCommand command);
        }

        public string SnippetId { get; }
    }
}
