namespace SnippetsApi.Features.Version1.Snippets.Infrastructure
{
    using System;
    using Contracts.Models;
    using Contracts.Services;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class CreateSnippetQueryHandler
        : CreateSnippetQuery.IHandler
    {
        private readonly ISnippetMapper snippetMapper;

        public CreateSnippetQueryHandler(
            ISnippetMapper snippetMapper)
        {
            this.snippetMapper = snippetMapper;
        }

        public SnippetModel Handle(
            CreateSnippetQuery query)
        {
            var snippet = new Snippet(
                description: query.Description,
                content: query.Content,
                createdDate: DateTime.UtcNow,
                updatedDate: DateTime.UtcNow);

            this.snippetMapper
                .Insert(snippet: snippet);

            return new SnippetModel(
                id: snippet.Id.ToString(),
                description: snippet.Description,
                content: snippet.Content,
                createDate: snippet.CreatedDate,
                lastUpdateDate: snippet.UpdatedDate);
        }
    }
}
