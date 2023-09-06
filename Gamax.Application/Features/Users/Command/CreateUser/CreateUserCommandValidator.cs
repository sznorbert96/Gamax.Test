using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamax.Application.Features.Users.Command.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
