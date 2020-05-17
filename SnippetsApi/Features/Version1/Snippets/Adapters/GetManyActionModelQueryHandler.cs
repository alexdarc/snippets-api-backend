namespace SnippetsApi.Features.Version1.Snippets.Adapters
{
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Actions.Get;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;

    public class GetManyActionModelQueryHandler
        : GetManyActionModelQuery.IHandler
    {
        private readonly SnippetListQuery.IHandler snippetListQueryHandler;

        public GetManyActionModelQueryHandler(
            SnippetListQuery.IHandler snippetListQueryHandler)
        {
            this.snippetListQueryHandler = snippetListQueryHandler;
        }

        public Option<GetManyActionModelQuery.Result> Handle(
            GetManyActionModelQuery query)
        {
            // TODO: Remove, cuz it's already validate by default
            if (!query.ModelState.IsValid)
            {
                Option.None<GetManyActionModelQuery.Result>();
            }

            return Option.Some(
                value: new GetManyActionModelQuery.Result(
                    snippetList: this.snippetListQueryHandler
                        .Handle(
                            query: new SnippetListQuery(
                                limit: query.Limit,
                                offset: query.Offset))));
        }
    }
}
