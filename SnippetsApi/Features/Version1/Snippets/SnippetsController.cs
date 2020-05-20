namespace SnippetsApi.Features.Version1.Snippets
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Common.Mongo;
    using Microsoft.AspNetCore.Mvc;
    using SnippetsApi.Features.Version1.Snippets.Actions.Create;
    using SnippetsApi.Features.Version1.Snippets.Actions.Delete;
    using SnippetsApi.Features.Version1.Snippets.Actions.GetSingle;
    using SnippetsApi.Features.Version1.Snippets.Actions.List;
    using SnippetsApi.Features.Version1.Snippets.Actions.Update;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class SnippetsController
        : ApiVersion1Controller
    {
        private readonly ListActionModelQuery.IHandler listActionModelQueryHandler;

        private readonly CreateActionModelQuery.IHandler createActionModelQueryHandler;

        private readonly GetActionModelQuery.IHandler getActionModelQueryHandler;

        private readonly UpdateActionModelQuery.IHandler updateActionModelQueryHandler;

        private readonly DeleteActionModelQuery.IHandler deleteActionModelQueryHandler;

        public SnippetsController(
            ListActionModelQuery.IHandler listActionModelQueryHandler,
            CreateActionModelQuery.IHandler createActionModelQueryHandler,
            GetActionModelQuery.IHandler getActionModelQueryHandler,
            UpdateActionModelQuery.IHandler updateActionModelQueryHandler,
            DeleteActionModelQuery.IHandler deleteActionModelQueryHandler)
        {
            this.listActionModelQueryHandler = listActionModelQueryHandler;
            this.createActionModelQueryHandler = createActionModelQueryHandler;
            this.getActionModelQueryHandler = getActionModelQueryHandler;
            this.updateActionModelQueryHandler = updateActionModelQueryHandler;
            this.deleteActionModelQueryHandler = deleteActionModelQueryHandler;
        }

        [HttpGet]
        public ActionResult<List<SnippetModel>> List(
            [FromQuery] ListRequestModel requestModel)
        {
            return this.listActionModelQueryHandler
                .Handle(
                    query: new ListActionModelQuery(
                        limit: requestModel.Limit,
                        offset: requestModel.Offset))
                .Match<ActionResult<List<SnippetModel>>>(
                    some: resultModel => resultModel.SnippetList
                        .ToList(),
                    none: () => new BadRequestResult());
        }

        [HttpGet(template: "{id:length(24)}")]
        public ActionResult<SnippetModel> Get(
            [FromRoute] GetRequestModel requestModel)
        {
            return this.getActionModelQueryHandler
                .Handle(
                    query: new GetActionModelQuery(
                        snippetId: requestModel.Id))
                .Match<ActionResult<SnippetModel>>(
                    some: resultModel => resultModel.SnippetModel,
                    none: () => new NotFoundResult());
        }

        [HttpPost]
        public ActionResult<SnippetModel> Create(
            [FromBody] CreateRequestModel requestModel)
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


        [HttpPut(template: "{id:length(24)}")]
        public ActionResult<SnippetModel> Update(
            [FromRoute] [ObjectId] [Required] string Id,
            [FromBody] UpdateRequestModel requestModel)
        {
            return this.updateActionModelQueryHandler
                .Handle(
                    query: new UpdateActionModelQuery(
                        snippetId: Id,
                        description: requestModel.Description,
                        content: requestModel.Content))
                .Match<ActionResult<SnippetModel>>(
                    some: resultModel => resultModel.SnippetModel,
                    none: () => new NotFoundResult());
        }

        [HttpDelete(template: "{id:length(24)}")]
        public IActionResult Delete(
            [FromRoute] DeleteRequestModel requestModel)
        {
            return this.deleteActionModelQueryHandler
                .Handle(
                    query: new DeleteActionModelQuery(
                        snippetId: requestModel.Id))
                .Match<ActionResult>(
                    some: resultModel => new NoContentResult(),
                    none: () => new NotFoundResult());
        }
    }
}
