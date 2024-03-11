using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Net6.API.CleanArchitecture.Domain.Exceptions;

public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException()
    { }

    public InvalidCredentialsException(string message)
        : base(message)
    { }

    public InvalidCredentialsException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
