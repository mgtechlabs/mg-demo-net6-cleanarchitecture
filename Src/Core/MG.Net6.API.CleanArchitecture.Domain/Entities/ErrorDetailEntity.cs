using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Net6.API.CleanArchitecture.Domain.Entities;

public class ErrorDetailEntity
{
    public string Title { get; set; } = "";
    public string[] Errors { get; set; } = new string[] { };
    public string DeveloperMessage { get; set; } = string.Empty;
}
