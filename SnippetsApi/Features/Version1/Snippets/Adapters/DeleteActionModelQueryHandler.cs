namespace SnippetsApi.Features.Version1.Snippets.Adapters
{
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Actions.Delete;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;

    public class DeleteActionModelQueryHandler
        : DeleteActionModelQuery.IHandler
    {
        private readonly SnippetQuery.IHandler snippetQueryHandler;

        private readonly DeleteSnippetCommand.IHandler deleteSnippetCommandHandler;

        public DeleteActionModelQueryHandler(
            SnippetQuery.IHandler snippetQueryHandler,
            DeleteSnippetCommand.IHandler deleteSnippetCommandHandler)
        {
            this.snippetQueryHandler = snippetQueryHandler;
            this.deleteSnippetCommandHandler = deleteSnippetCommandHandler;
        }

        public Option<DeleteActionModelQuery.Result> Handle(
            DeleteActionModelQuery query)
        {
            var snippet = this.snippetQueryHandler
                .Handle(
                    query: new SnippetQuery(
                        snippetId: query.SnippetId));

            if (snippet == null)
            {
                return Option.None<DeleteActionModelQuery.Result>();
            }

            this.deleteSnippetCommandHandler
                .Handle(
                    command: new DeleteSnippetCommand(
                        snippetId: query.SnippetId));

            return Option.Some(
                value: new DeleteActionModelQuery.Result(
                    snippetId: query.SnippetId));
        }
    }
}
