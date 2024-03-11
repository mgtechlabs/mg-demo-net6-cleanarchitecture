using AutoMapper;
using MediatR;
using MG.Net6.API.CleanArchitecture.Application.Utils;
using MG.Net6.API.CleanArchitecture.Domain.Configurations;
using MG.Net6.API.CleanArchitecture.Domain.Contracts.Repositories;
using MG.Net6.API.CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Net6.API.CleanArchitecture.Application.Commands.CreateToDoItemCommand;

 

/// <summary>
/// This class handles the command to update data and build response
/// </summary>
public class CreateToDoItemCommandHandler : IRequestHandler<CreateToDoItemCommand, CreateToDoItemCommandViewModel>
{
    private IMapper mapper;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IToDoRepository toDoRepository;
 
    public CreateToDoItemCommandHandler
        (
            IMapper mapper,
            IToDoRepository toDoRepository,
            IOptions<SystemParameterConfiguration> systemParamOptions
        )
    {
        this.mapper = mapper;
        this.toDoRepository = toDoRepository;
        this.systemParamOptions = systemParamOptions.Value;
    }

    public async Task<CreateToDoItemCommandViewModel> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<CreateToDoItemCommand, ToDoEntity>(request);
        entity.Title = "Todo-1";
        entity.IsComplete = false;

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            entity = await toDoRepository.SaveAsync(entity);
            scope.Complete();
        }
        var result = mapper.Map<ToDoEntity, CreateToDoItemCommandViewModel>(entity);

        
        return result;
    }
}