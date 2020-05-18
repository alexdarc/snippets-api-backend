namespace SnippetsApi.Features.Version1.Snippets.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts.Services;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class SnippetListQueryHandler
        : SnippetListQuery.IHandler
    {
        private readonly ISnippetMapper snippetMapper;

        public SnippetListQueryHandler(
            ISnippetMapper snippetMapper)
        {
            this.snippetMapper = snippetMapper;
        }

        public IEnumerable<SnippetModel> Handle(
            SnippetListQuery query)
        {
            return this.snippetMapper
                .GetMany(
                    limit: query.Limit,
                    skip: query.Offset)
                .Select(selector: x => new SnippetModel(
                    id: x.Id.ToString(),
                    description: x.Description,
                    content: x.Content,
                    createDate: x.CreatedDate,
                    lastUpdateDate: x.UpdatedDate));
        }
    }
}
