namespace SnippetsApi.Features.Version1.Snippets.Adapters
{
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Actions.Get;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;

    public class GetActionModelQueryHandler
        : GetActionModelQuery.IHandler
    {
        private readonly SnippetsQuery.IHandler snippetsQueryHandler;

        public GetActionModelQueryHandler(
            SnippetsQuery.IHandler snippetsQueryHandler)
        {
            this.snippetsQueryHandler = snippetsQueryHandler;
        }

        public Option<GetActionModelQuery.Result> Handle(
            GetActionModelQuery query)
        {
            if (!query.ModelState.IsValid)
            {
                Option.None<GetActionModelQuery.Result>();
            }

            return Option.Some(
                value: new GetActionModelQuery.Result(
                    snippetList: this.snippetsQueryHandler
                        .Handle(
                            query: new SnippetsQuery(
                                limit: query.Limit))));
        }
    }
}
