namespace SnippetsApi.Features.Version1.Snippets.Actions.List
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class ListActionModelQuery
    {
        public ListActionModelQuery(
            int limit,
            int offset)
        {
            this.Limit = limit;
            this.Offset = offset;
        }

        public interface IHandler
        {
            Option<Result> Handle(
                ListActionModelQuery query);
        }

        public int Limit { get; }

        public int Offset { get; }

        public class Result
        {
            public Result(
                IEnumerable<SnippetModel> snippetList)
            {
                this.SnippetList = snippetList;
            }

            public IEnumerable<SnippetModel> SnippetList { get; }
        }
    }
}
