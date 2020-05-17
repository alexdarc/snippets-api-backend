namespace SnippetsApi.Features.Version1.Snippets.Adapters.InfrastructureContracts
{
    using System.Collections.Generic;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class SnippetListQuery
    {
        public SnippetListQuery(
            int limit,
            int offset)
        {
            this.Limit = limit;
            this.Offset = offset;
        }

        public interface IHandler
        {
            IEnumerable<SnippetModel> Handle(
                SnippetListQuery query);
        }

        public int Limit { get; }

        public int Offset { get; }
    }
}
