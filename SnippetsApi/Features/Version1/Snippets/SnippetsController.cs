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
        private readonly GetManyActionModelQuery.IHandler getManyActionModelQueryHandler;

        private readonly CreateActionModelQuery.IHandler createActionModelQueryHandler;

        public SnippetsController(
            GetManyActionModelQuery.IHandler getManyActionModelQueryHandler,
            CreateActionModelQuery.IHandler createActionModelQueryHandler)
        {
            this.getManyActionModelQueryHandler = getManyActionModelQueryHandler;
            this.createActionModelQueryHandler = createActionModelQueryHandler;
        }

        [HttpGet]
        public ActionResult<List<SnippetModel>> GetMany(
            [FromQuery] GetManyRequestModel manyRequestModel)
        {
            return this.getManyActionModelQueryHandler
                .Handle(
                    query: new GetManyActionModelQuery(
                        modelState: this.ModelState,
                        limit: manyRequestModel.Limit,
                        offset: manyRequestModel.Offset))
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
