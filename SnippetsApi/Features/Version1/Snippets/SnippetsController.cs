namespace SnippetsApi.Features.Version1.Snippets
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using SnippetsApi.Features.Version1.Snippets.Actions.Create;
    using SnippetsApi.Features.Version1.Snippets.Actions.Get;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class SnippetsController
        : ApiVersion1Controller
    {
        private readonly GetActionModelQuery.IHandler getActionModelQueryHandler;

        private readonly CreateActionModelQuery.IHandler createActionModelQueryHandler;

        public SnippetsController(
            GetActionModelQuery.IHandler getActionModelQueryHandler,
            CreateActionModelQuery.IHandler createActionModelQueryHandler)
        {
            this.getActionModelQueryHandler = getActionModelQueryHandler;
            this.createActionModelQueryHandler = createActionModelQueryHandler;
        }

        [HttpGet]
        public ActionResult<List<SnippetModel>> Get(
            [FromQuery] GetRequestModel requestModel)
        {
            return this.getActionModelQueryHandler
                .Handle(
                    query: new GetActionModelQuery(
                        modelState: this.ModelState,
                        limit: requestModel.Limit,
                        offset: requestModel.Offset))
                .Match<ActionResult<List<SnippetModel>>>(
                    some: resultModel => new ObjectResult(
                        value: resultModel.SnippetList),
                    none: () => new BadRequestResult());
        }

        [HttpPost]
        public ActionResult<SnippetModel> Create(
            [FromQuery] CreateRequestModel requestModel)
        {
            return this.createActionModelQueryHandler
                .Handle(
                    query: new CreateActionModelQuery(
                        modelState: this.ModelState,
                        description: requestModel.Description,
                        content: requestModel.Content))
                .Match<ActionResult<SnippetModel>>(
                    some: resultModel => new ObjectResult(
                        value: resultModel.SnippetModel),
                    none: () => new BadRequestResult());
        }
    }
}
