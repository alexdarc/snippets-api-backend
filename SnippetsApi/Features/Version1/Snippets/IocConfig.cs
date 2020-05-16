namespace SnippetsApi.Features.Version1.Snippets
{
    using Contracts.Services;
    using Microsoft.Extensions.DependencyInjection;
    using SnippetsApi.Features.Version1.Snippets.Actions.Create;
    using SnippetsApi.Features.Version1.Snippets.Actions.Get;
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
                    snippetsQueryHandler: new SnippetsQueryHandler(
                        snippetMapper: snippetMapper)));

            services.AddSingleton<CreateActionModelQuery.IHandler>(
                implementationInstance: new CreateActionModelQueryHandler(
                    createSnippetQueryHandler: new CreateSnippetQueryHandler(
                        snippetMapper: snippetMapper)));
        }
    }
}
