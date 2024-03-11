using MediatR;

namespace MG.Net6.API.CleanArchitecture.Application.Commands.CreateToDoItemCommand;

/// <summary>
/// This class represents api's command input model and returns the response object
/// </summary>
public class CreateToDoItemCommand : IRequest<CreateToDoItemCommandViewModel>
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public bool IsCompleted { get; set; }
}