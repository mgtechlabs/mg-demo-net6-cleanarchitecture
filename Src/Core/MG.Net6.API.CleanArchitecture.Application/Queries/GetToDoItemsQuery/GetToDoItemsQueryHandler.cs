using AutoMapper;
using MediatR;
using MG.Net6.API.CleanArchitecture.Domain.Configurations;
using MG.Net6.API.CleanArchitecture.Domain.Contracts.Repositories;
using MG.Net6.API.CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Net6.API.CleanArchitecture.Application.Queries.GetToDoItemsQuery;

 

public class GetToDoItemsQueryHandler : IRequestHandler<GetToDoItemsQuery, IEnumerable<GetToDoItemsQueryViewModel>>
{

    private IMapper mapper;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IToDoRepository toDoRepository;

    public GetToDoItemsQueryHandler
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<GetToDoItemsQueryViewModel>> Handle(GetToDoItemsQuery request, CancellationToken cancellationToken)
    {
        var todoItems = await this.toDoRepository.FetchAsync();
        var results = mapper.Map<IEnumerable<ToDoEntity>, IEnumerable<GetToDoItemsQueryViewModel>>(todoItems);
        return results;
    }
}
