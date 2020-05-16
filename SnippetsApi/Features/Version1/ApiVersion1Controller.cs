namespace SnippetsApi.Features.Version1
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route(template: "api/v1/[controller]")]
    public abstract class ApiVersion1Controller
        : ControllerBase
    {
    }
}
