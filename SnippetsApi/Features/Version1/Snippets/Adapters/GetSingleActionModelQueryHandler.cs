namespace SnippetsApi.Features.Version1.Snippets.Adapters
{
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Actions.GetSingle;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class GetSingleActionModelQueryHandler
        : GetSingleActionModelQuery.IHandler
    {
        private readonly SnippetQuery.IHandler snippetQueryHandler;

        public GetSingleActionModelQueryHandler(
            SnippetQuery.IHandler snippetQueryHandler)
        {
            this.snippetQueryHandler = snippetQueryHandler;
        }

        public Option<GetSingleActionModelQuery.Result> Handle(
            GetSingleActionModelQuery query)
        {
            var snippet = this.snippetQueryHandler
                .Handle(
                    query: new SnippetQuery(
                        snippetId: query.SnippetId));

            if (snippet == null)
            {
                return Option.None<GetSingleActionModelQuery.Result>();
            }

            return Option.Some(
                value: new GetSingleActionModelQuery.Result(
                    snippetModel: new SnippetModel(
                        id: snippet.Id.ToString(),
                        description: snippet.Description,
                        content: snippet.Content,
                        createDate: snippet.CreatedDate,
                        lastUpdateDate: snippet.UpdatedDate)));
        }
    }
}
