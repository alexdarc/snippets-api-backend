namespace SnippetsApi.Features.Version1.Snippets.Infrastructure
{
    using Contracts.Services;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;

    public class DeleteSnippetCommandHandler
        : DeleteSnippetCommand.IHandler
    {
        private readonly ISnippetMapper snippetMapper;

        public DeleteSnippetCommandHandler(
            ISnippetMapper snippetMapper)
        {
            this.snippetMapper = snippetMapper;
        }

        public void Handle(
            DeleteSnippetCommand command)
        {
            this.snippetMapper
                .Remove(
                    id: command.SnippetId);
        }
    }
}
