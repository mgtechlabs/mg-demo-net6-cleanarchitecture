using AutoMapper;
using MG.Net6.API.CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Net6.API.CleanArchitecture.Application.Queries.GetToDoItemsQuery;


public class GetToDoItemsQueryMappingProfile : Profile
{
    public GetToDoItemsQueryMappingProfile()
    {
        CreateMap<ToDoEntity, GetToDoItemsQueryViewModel>();
    }
}