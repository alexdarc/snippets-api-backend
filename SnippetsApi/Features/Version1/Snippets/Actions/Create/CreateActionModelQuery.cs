namespace SnippetsApi.Features.Version1.Snippets.Actions.Create
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class CreateActionModelQuery
    {
        public CreateActionModelQuery(
            string description,
            string content)
        {
            this.Description = description;
            this.Content = content;
        }

        public interface IHandler
        {
            Option<Result> Handle(
                CreateActionModelQuery query);
        }

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
