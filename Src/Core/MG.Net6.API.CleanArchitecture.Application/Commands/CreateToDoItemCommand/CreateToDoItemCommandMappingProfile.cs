using AutoMapper;
using MG.Net6.API.CleanArchitecture.Domain.Entities;

namespace MG.Net6.API.CleanArchitecture.Application.Commands.CreateToDoItemCommand;

/// <summary>
/// This class defines the configuration using profiles.
/// </summary>
public class CreateToDoItemCommandMappingProfile : Profile
{
    public CreateToDoItemCommandMappingProfile()
    {
        CreateMap<CreateToDoItemCommand, ToDoEntity>();
        CreateMap<ToDoEntity, CreateToDoItemCommandViewModel>();
    }
}