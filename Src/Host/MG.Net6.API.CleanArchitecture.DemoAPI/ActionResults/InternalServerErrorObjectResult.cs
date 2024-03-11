using Microsoft.AspNetCore.Mvc;

namespace MG.Net6.API.CleanArchitecture.DemoAPI.ActionResults;

public class InternalServerErrorObjectResult : ObjectResult
{
    public InternalServerErrorObjectResult(object error)
        : base(error)
    {
        StatusCode = StatusCodes.Status500InternalServerError;
    }
}
