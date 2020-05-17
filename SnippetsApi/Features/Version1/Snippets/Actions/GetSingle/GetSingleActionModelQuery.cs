namespace SnippetsApi.Features.Version1.Snippets.Actions.GetSingle
{
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class GetSingleActionModelQuery
    {
        public GetSingleActionModelQuery(
            string snippetId)
        {
            this.SnippetId = snippetId;
        }

        public interface IHandler
        {
            Option<Result> Handle(
                GetSingleActionModelQuery query);
        }

        public string SnippetId { get; }

        public class Result
        {
            public Result(
                SnippetModel snippetModel)
            {
                this.SnippetModel = snippetModel;
            }

            public SnippetModel SnippetModel { get; }
        }
    }
}
