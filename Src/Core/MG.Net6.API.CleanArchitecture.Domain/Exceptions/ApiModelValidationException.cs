using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Net6.API.CleanArchitecture.Domain.Exceptions;

/// <summary>
///     Api validation exception
/// </summary>
public class ApiModelValidationException : Exception
{
    public string[] Errors { get; private set; }

    /// <summary>
    ///     ctor
    /// </summary>
    public ApiModelValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new string[] { };
    }

    public ApiModelValidationException(string[] errors)
        : this()
    {
        Errors = errors;
    }
}
