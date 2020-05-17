namespace SnippetsApi.Features.Version1.Snippets.Infrastructure
{
    using Contracts.Models;
    using Contracts.Services;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;

    public class SnippetQueryHandler
        : SnippetQuery.IHandler
    {
        private readonly ISnippetMapper snippetMapper;

        public SnippetQueryHandler(
            ISnippetMapper snippetMapper)
        {
            this.snippetMapper = snippetMapper;
        }

        public Snippet Handle(
            SnippetQuery query)
        {
            return this.snippetMapper.Get(
                id: query.SnippetId);
        }
    }
}
