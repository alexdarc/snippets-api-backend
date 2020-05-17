namespace SnippetsApi.Features.Version1.Snippets.Actions.Delete
{
    using Optional;

    public class DeleteActionModelQuery
    {
        public DeleteActionModelQuery(
            string snippetId)
        {
            this.SnippetId = snippetId;
        }

        public interface IHandler
        {
            Option<Result> Handle(
                DeleteActionModelQuery query);
        }

        public string SnippetId { get; }

        public class Result
        {
            public Result(
                string snippetId)
            {
                this.SnippetId = snippetId;
            }

            public string SnippetId { get; }
        }
    }
}
