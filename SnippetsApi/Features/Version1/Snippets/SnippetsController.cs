namespace SnippetsApi.Features.Version1.Snippets
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using SnippetsApi.Features.Version1.Snippets.Actions.Get;
    using SnippetsApi.Features.Version1.Snippets.Models;

    public class SnippetsController
        : ApiVersion1Controller
    {
        private readonly GetActionModelQuery.IHandler getActionModelQueryHandler;

        public SnippetsController(
            GetActionModelQuery.IHandler getActionModelQueryHandler)
        {
            this.getActionModelQueryHandler = getActionModelQueryHandler;
        }

        [HttpGet]
        public ActionResult<List<SnippetModel>> Get(
            GetRequestModel requestModel)
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
    }
}
