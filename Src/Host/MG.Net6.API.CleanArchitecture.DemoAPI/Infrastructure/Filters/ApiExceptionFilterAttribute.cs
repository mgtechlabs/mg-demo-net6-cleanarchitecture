using MG.Net6.API.CleanArchitecture.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MG.Net6.API.CleanArchitecture.Domain.Entities;

namespace MG.Net6.API.CleanArchitecture.DemoAPI.Infrastructure.Filters;
 

/// <summary>
///     API exception filter.
/// </summary>
public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{

    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
    private readonly IWebHostEnvironment env;

    /// <summary>
    ///     ctor
    /// </summary>
    public ApiExceptionFilterAttribute(IWebHostEnvironment env)
    {
        this.env = env;

        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ApiModelValidationException), HandleValidationException },
                { typeof(EntityNotFoundException), HandleNotFoundException },
                { typeof(EntityAlreadyExistsException), HandleAlreadyExistsException },
                { typeof(InvalidCredentialsException), HandleInvalidCredentialsException },
            };
    }

    /// <summary>
    ///     
    /// </summary>
    /// <param name="context"></param>
    public override void OnException(ExceptionContext context)
    {
        HandleException(context);

        base.OnException(context);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    private void HandleException(ExceptionContext context)
    {
        Type type = context.Exception.GetType();
        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            return;
        }

        HandleUnknownException(context);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    private void HandleUnknownException(ExceptionContext context)
    {
        ErrorDetailEntity details = new ErrorDetailEntity()
        {
            Title = "An error occurred while processing your request.",
            DeveloperMessage = env.IsDevelopment() ? context.Exception.Message : null
            //DeveloperMessage = context.Exception.Message
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    private void HandleValidationException(ExceptionContext context)
    {
        ApiModelValidationException exception = context.Exception as ApiModelValidationException;

        ErrorDetailEntity details = new ErrorDetailEntity()
        {
            Title = exception.Message,
            Errors = exception.Errors ?? new string[] { }
        };

        context.Result = new BadRequestObjectResult(details);

        context.ExceptionHandled = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    private void HandleNotFoundException(ExceptionContext context)
    {
        EntityNotFoundException exception = context.Exception as EntityNotFoundException;

        ErrorDetailEntity details = new ErrorDetailEntity()
        {
            Title = exception.Message ?? "The specified resource was not found.",
        };

        context.Result = new BadRequestObjectResult(details);

        context.ExceptionHandled = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    private void HandleAlreadyExistsException(ExceptionContext context)
    {
        EntityAlreadyExistsException exception = context.Exception as EntityAlreadyExistsException;

        ErrorDetailEntity details = new ErrorDetailEntity()
        {
            Title = exception.Message ?? "The specified resource already exists.",
        };

        context.Result = new BadRequestObjectResult(details);

        context.ExceptionHandled = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    private void HandleInvalidCredentialsException(ExceptionContext context)
    {
        InvalidCredentialsException exception = context.Exception as InvalidCredentialsException;

        ErrorDetailEntity details = new ErrorDetailEntity()
        {
            Title = exception.Message ?? "User is not authorized to access the resource and/or to perform an operation .",
        };

        context.Result = new UnauthorizedObjectResult(details);

        context.ExceptionHandled = true;
    }
}
