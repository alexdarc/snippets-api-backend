namespace SnippetsApi.Features.Version1.Snippets.Adapters
{
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Actions.Update;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class UpdateActionModelQueryHandler
        : UpdateActionModelQuery.IHandler
    {
        private readonly SnippetQuery.IHandler snippetQueryHandler;

        private readonly UpdateSnippetCommand.IHandler updateSnippetCommandHandler;

        public UpdateActionModelQueryHandler(
            SnippetQuery.IHandler snippetQueryHandler,
            UpdateSnippetCommand.IHandler updateSnippetCommandHandler)
        {
            this.snippetQueryHandler = snippetQueryHandler;
            this.updateSnippetCommandHandler = updateSnippetCommandHandler;
        }

        public Option<UpdateActionModelQuery.Result> Handle(
            UpdateActionModelQuery query)
        {
            var snippet = this.snippetQueryHandler
                .Handle(
                    query: new SnippetQuery(
                        snippetId: query.SnippetId));

            if (snippet == null)
            {
                return Option.None<UpdateActionModelQuery.Result>();
            }

            var snippetModel = new SnippetModel(
                id: query.SnippetId,
                description: query.Description,
                content: query.Content,
                createDate: snippet.CreatedDate,
                lastUpdateDate: snippet.UpdatedDate);
            this.updateSnippetCommandHandler
                .Handle(
                    command: new UpdateSnippetCommand(
                        snippetId: query.SnippetId,
                        snippetModel: snippetModel));

            return Option.Some(
                value: new UpdateActionModelQuery.Result(
                    snippetModel: snippetModel));
        }
    }
}
