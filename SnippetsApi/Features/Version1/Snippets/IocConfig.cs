namespace SnippetsApi.Features.Version1.Snippets
{
    using Contracts.Services;
    using Microsoft.Extensions.DependencyInjection;
    using SnippetsApi.Features.Version1.Snippets.Actions.Create;
    using SnippetsApi.Features.Version1.Snippets.Actions.Delete;
    using SnippetsApi.Features.Version1.Snippets.Actions.Get;
    using SnippetsApi.Features.Version1.Snippets.Actions.GetSingle;
    using SnippetsApi.Features.Version1.Snippets.Actions.Update;
    using SnippetsApi.Features.Version1.Snippets.Adapters;
    using SnippetsApi.Features.Version1.Snippets.Infrastructure;

    public static class IocConfig
    {
        public static void RegisterDependencies(
            IServiceCollection services,
            ISnippetMapper snippetMapper)
        {
            services.AddSingleton<GetManyActionModelQuery.IHandler>(
                implementationInstance: new GetManyActionModelQueryHandler(
                    snippetListQueryHandler: new SnippetListQueryHandler(
                        snippetMapper: snippetMapper)));

            services.AddSingleton<CreateActionModelQuery.IHandler>(
                implementationInstance: new CreateActionModelQueryHandler(
                    createSnippetQueryHandler: new CreateSnippetQueryHandler(
                        snippetMapper: snippetMapper)));

            var snippetQueryHandler = new SnippetQueryHandler(
                snippetMapper: snippetMapper);

            services.AddSingleton<GetSingleActionModelQuery.IHandler>(
                implementationInstance: new GetSingleActionModelQueryHandler(
                    snippetQueryHandler: snippetQueryHandler));

            services.AddSingleton<UpdateActionModelQuery.IHandler>(
                implementationInstance: new UpdateActionModelQueryHandler(
                    snippetQueryHandler: snippetQueryHandler,
                    updateSnippetCommandHandler: new UpdateSnippetCommandHandler(
                        snippetMapper: snippetMapper)));

            services.AddSingleton<DeleteActionModelQuery.IHandler>(
                implementationInstance: new DeleteActionModelQueryHandler(
                    snippetQueryHandler: snippetQueryHandler,
                    deleteSnippetCommandHandler: new DeleteSnippetCommandHandler(
                        snippetMapper: snippetMapper)));
        }
    }
}
