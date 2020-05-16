namespace SnippetsApi.Features.Version1.Snippets.Adapters
{
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Actions.Get;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;

    public class GetManyActionModelQueryHandler
        : GetManyActionModelQuery.IHandler
    {
        private readonly SnippetsQuery.IHandler snippetsQueryHandler;

        public GetManyActionModelQueryHandler(
            SnippetsQuery.IHandler snippetsQueryHandler)
        {
            this.snippetsQueryHandler = snippetsQueryHandler;
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
                    snippetList: this.snippetsQueryHandler
                        .Handle(
                            query: new SnippetsQuery(
                                limit: query.Limit,
                                offset: query.Offset))));
        }
    }
}
