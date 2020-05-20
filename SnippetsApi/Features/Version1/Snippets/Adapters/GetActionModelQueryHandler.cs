namespace SnippetsApi.Features.Version1.Snippets.Adapters
{
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Actions.GetSingle;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class GetActionModelQueryHandler
        : GetActionModelQuery.IHandler
    {
        private readonly SnippetQuery.IHandler snippetQueryHandler;

        public GetActionModelQueryHandler(
            SnippetQuery.IHandler snippetQueryHandler)
        {
            this.snippetQueryHandler = snippetQueryHandler;
        }

        public Option<GetActionModelQuery.Result> Handle(
            GetActionModelQuery query)
        {
            var snippet = this.snippetQueryHandler
                .Handle(
                    query: new SnippetQuery(
                        snippetId: query.SnippetId));

            if (snippet == null)
            {
                return Option.None<GetActionModelQuery.Result>();
            }

            return Option.Some(
                value: new GetActionModelQuery.Result(
                    snippetModel: new SnippetModel(
                        id: snippet.Id.ToString(),
                        description: snippet.Description,
                        content: snippet.Content,
                        createDate: snippet.CreatedDate,
                        lastUpdateDate: snippet.UpdatedDate)));
        }
    }
}
