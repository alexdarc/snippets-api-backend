namespace SnippetsApi.Features.Version1.Snippets.Adapters
{
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Actions.List;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;

    public class ListActionModelQueryHandler
        : ListActionModelQuery.IHandler
    {
        private readonly SnippetListQuery.IHandler snippetListQueryHandler;

        public ListActionModelQueryHandler(
            SnippetListQuery.IHandler snippetListQueryHandler)
        {
            this.snippetListQueryHandler = snippetListQueryHandler;
        }

        public Option<ListActionModelQuery.Result> Handle(
            ListActionModelQuery query)
        {
            return Option.Some(
                value: new ListActionModelQuery.Result(
                    snippetList: this.snippetListQueryHandler
                        .Handle(
                            query: new SnippetListQuery(
                                limit: query.Limit,
                                offset: query.Offset))));
        }
    }
}
