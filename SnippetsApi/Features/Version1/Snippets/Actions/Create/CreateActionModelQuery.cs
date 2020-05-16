namespace SnippetsApi.Features.Version1.Snippets.Actions.Create
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Optional;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class CreateActionModelQuery
    {
        public CreateActionModelQuery(
            ModelStateDictionary modelState,
            string description,
            string content)
        {
            this.ModelState = modelState;
            this.Description = description;
            this.Content = content;
        }

        public interface IHandler
        {
            Option<Result> Handle(
                CreateActionModelQuery query);
        }

        public ModelStateDictionary ModelState { get; }

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
