namespace SnippetsApi
{
    using Infrastructure;
    using Infrastructure.Mappers;
    using Microsoft.Extensions.DependencyInjection;

    public static class IocConfig
    {
        public static void RegisterDependencies(
            IServiceCollection services)
        {
            var snippetMapper = new SnippetMapper(
                mongoCollections: new MongoCollections(
                    database: MongoFactory.GetDatabase()));

            Features.Version1.Snippets.IocConfig
                .RegisterDependencies(
                    services: services,
                    snippetMapper: snippetMapper);
        }
    }
}
