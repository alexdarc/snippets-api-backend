namespace SnippetsApi.Features.Version1.Snippets.Actions.Update
{
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class UpdateActionModelQuery
    {
        public UpdateActionModelQuery(
            string snippetId,
            string description,
            string content)
        {
            this.SnippetId = snippetId;
            this.Description = description;
            this.Content = content;
        }

        public interface IHandler
        {
            Option<Result> Handle(
                UpdateActionModelQuery query);
        }

        public string SnippetId { get; }

        public string Description { get; }

        public string Content { get; }

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
