namespace SnippetsApi.Features.Version1.Snippets.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts.Services;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class SnippetsQueryHandler
        : SnippetsQuery.IHandler
    {
        private readonly ISnippetMapper snippetMapper;

        public SnippetsQueryHandler(
            ISnippetMapper snippetMapper)
        {
            this.snippetMapper = snippetMapper;
        }

        public IEnumerable<SnippetModel> Handle(
            SnippetsQuery query)
        {
            return this.snippetMapper
                .GetMany(limit: query.Limit)
                .Select(selector: x => new SnippetModel(
                    id: x.Id,
                    description: x.Description,
                    content: x.Content));
        }
    }
}
