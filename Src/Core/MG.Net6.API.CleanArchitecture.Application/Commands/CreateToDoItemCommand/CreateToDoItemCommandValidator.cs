using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Net6.API.CleanArchitecture.Application.Commands.CreateToDoItemCommand;

 

/// <summary>
/// create rules for attributes
/// </summary>
public class CreateToDoItemCommandValidator : AbstractValidator<CreateToDoItemCommand>
{
    public CreateToDoItemCommandValidator()
    {
        RuleFor(query => query.Title)
                  .NotNull().NotEmpty().WithMessage("Not a valid document type.");
    }
}