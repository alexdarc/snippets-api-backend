namespace SnippetsApi.Features.Version1.Snippets.Actions.Get
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class GetActionModelQuery
    {
        public GetActionModelQuery(
            ModelStateDictionary modelState,
            int limit,
            int offset)
        {
            this.ModelState = modelState;
            this.Limit = limit;
            this.Offset = offset;
        }

        public interface IHandler
        {
            Option<Result> Handle(
                GetActionModelQuery query);
        }

        public ModelStateDictionary ModelState { get; }

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
