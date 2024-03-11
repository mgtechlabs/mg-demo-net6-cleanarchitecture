using MediatR;
using MG.Net6.API.CleanArchitecture.Application.Commands.CreateToDoItemCommand;
using MG.Net6.API.CleanArchitecture.Application.Queries.GetToDoItemsQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MG.Net6.API.CleanArchitecture.DemoAPI.Controllers.v1;

[Route("api/v1/todo")]
[ApiController]
public class ToDoController : ApiBaseController
{
    public ToDoController(IMediator mediator) : base(mediator) { }

    [HttpPost("getToDoItems")]
    [ProducesResponseType(typeof(IEnumerable<GetToDoItemsQueryViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<IEnumerable<GetToDoItemsQueryViewModel>>> GetApplications([FromBody] GetToDoItemsQuery query)
    {
        return Single(await QueryAsync(query));
    }

    [HttpPost("createToDoItem")]
    [ProducesResponseType(typeof(CreateToDoItemCommandViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<CreateToDoItemCommandViewModel>> CreateApplication([FromBody] CreateToDoItemCommand command)
    {
        return Single(await CommandAsync(command));
    }
}
