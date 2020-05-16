namespace SnippetsApi.Features.Version1.Snippets.Adapters
{
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Actions.Create;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;

    public class CreateActionModelQueryHandler
        : CreateActionModelQuery.IHandler
    {
        private readonly CreateSnippetQuery.IHandler createSnippetQueryHandler;

        public CreateActionModelQueryHandler(
            CreateSnippetQuery.IHandler createSnippetQueryHandler)
        {
            this.createSnippetQueryHandler = createSnippetQueryHandler;
        }

        public Option<CreateActionModelQuery.Result> Handle(
            CreateActionModelQuery query)
        {
            // TODO: Remove, cuz it's already validate by default
            if (!query.ModelState.IsValid)
            {
                return Option.None<CreateActionModelQuery.Result>();
            }

            var snippetModel = this.createSnippetQueryHandler
                .Handle(
                    query: new CreateSnippetQuery(
                        description: query.Description,
                        content: query.Content));

            return Option.Some(
                value: new CreateActionModelQuery.Result(
                    snippetModel: snippetModel));
        }
    }
}
