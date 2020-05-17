namespace SnippetsApi.Features.Version1.Snippets.Actions.GetSingle
{
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class GetSingleActionModelQuery
    {
        public GetSingleActionModelQuery(
            string id)
        {
            this.Id = id;
        }

        public interface IHandler
        {
            Option<Result> Handle(
                GetSingleActionModelQuery query);
        }

        public string Id { get; }

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
