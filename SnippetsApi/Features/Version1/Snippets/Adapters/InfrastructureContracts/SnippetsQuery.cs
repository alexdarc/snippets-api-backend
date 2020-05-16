namespace SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts
{
    using System.Collections.Generic;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class SnippetsQuery
    {
        public SnippetsQuery(
            int limit)
        {
            this.Limit = limit;
        }

        public interface IHandler
        {
            IEnumerable<SnippetModel> Handle(
                SnippetsQuery query);
        }

        public int Limit { get; }
    }
}
