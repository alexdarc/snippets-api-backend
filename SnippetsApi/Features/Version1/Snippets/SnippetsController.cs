namespace SnippetsApi.Features.Version1.Snippets
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using SnippetsApi.Features.Version1.Snippets.Actions.Create;
    using SnippetsApi.Features.Version1.Snippets.Actions.Get;
    using SnippetsApi.Features.Version1.Snippets.Actions.GetSingle;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class SnippetsController
        : ApiVersion1Controller
    {
        private readonly GetManyActionModelQuery.IHandler getManyActionModelQueryHandler;

        private readonly CreateActionModelQuery.IHandler createActionModelQueryHandler;

        private readonly GetSingleActionModelQuery.IHandler getSingleActionModelQueryHandler;

        public SnippetsController(
            GetManyActionModelQuery.IHandler getManyActionModelQueryHandler,
            CreateActionModelQuery.IHandler createActionModelQueryHandler,
            GetSingleActionModelQuery.IHandler getSingleActionModelQueryHandler)
        {
            this.getManyActionModelQueryHandler = getManyActionModelQueryHandler;
            this.createActionModelQueryHandler = createActionModelQueryHandler;
            this.getSingleActionModelQueryHandler = getSingleActionModelQueryHandler;
        }

        [HttpGet]
        public ActionResult<List<SnippetModel>> GetMany(
            [FromQuery] GetManyRequestModel requestModel)
        {
            return this.getManyActionModelQueryHandler
                .Handle(
                    query: new GetManyActionModelQuery(
                        modelState: this.ModelState,
                        limit: requestModel.Limit,
                        offset: requestModel.Offset))
                .Match<ActionResult<List<SnippetModel>>>(
                    some: resultModel => resultModel.SnippetList
                        .ToList(),
                    none: () => new BadRequestResult());
        }

        [HttpGet(template: "{id:length(24)}")]
        public ActionResult<SnippetModel> GetSingle(
            [FromRoute] GetSingleRequestModel requestModel)
        {
            return this.getSingleActionModelQueryHandler
                .Handle(
                    query: new GetSingleActionModelQuery(
                        id: requestModel.Id))
                .Match<ActionResult<SnippetModel>>(
                    some: resultModel => resultModel.SnippetModel,
                    none: () => new NotFoundResult());
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
                    some: resultModel => resultModel.SnippetModel,
                    none: () => new BadRequestResult());
        }
    }
}
