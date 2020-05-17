namespace SnippetsApi.Features.Version1.Snippets.Infrastructure
{
    using System;
    using Common.Contracts;
    using Contracts.Models;
    using Contracts.Services;
    using SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts;

    public class UpdateSnippetCommandHandler
        : UpdateSnippetCommand.IHandler
    {
        private readonly ISnippetMapper snippetMapper;

        public UpdateSnippetCommandHandler(
            ISnippetMapper snippetMapper)
        {
            this.snippetMapper = snippetMapper;
        }

        public void Handle(
            UpdateSnippetCommand command)
        {
            this.snippetMapper
                .Update(
                    id: command.SnippetId,
                    updateInstructions: new UpdateInstructions<Snippet>()
                        .Set(expression: x => x.Content, value: command.SnippetModel.Content)
                        .Set(expression: x => x.Description, value: command.SnippetModel.Description)
                        .Set(expression: x => x.UpdatedDate, value: DateTime.UtcNow));
        }
    }
}
