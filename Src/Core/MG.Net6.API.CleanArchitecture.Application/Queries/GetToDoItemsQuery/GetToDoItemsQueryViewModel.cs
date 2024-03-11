using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Net6.API.CleanArchitecture.Application.Queries.GetToDoItemsQuery;

public class GetToDoItemsQueryViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsComplete { get; set; }
}