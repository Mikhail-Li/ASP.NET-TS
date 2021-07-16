using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Infrastructure.Constants;
using Timesheets.Models.Dto;

namespace Timesheets.Infrastructure.Validation
{
    public class UserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        private static readonly int _minPasswordLength = 6;

        public UserRequestValidator(IUserManager userManager)
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage(ValidationMessages.InvalidUsername);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(ValidationMessages.InvalidPassword);

            RuleFor(x => x.Password.Length)
                .GreaterThanOrEqualTo(_minPasswordLength)
                .WithMessage(ValidationMessages.InvalidPasswordLength);

            RuleFor(x => x.Role)
                .NotEmpty()
                .WithMessage(ValidationMessages.InvalidRole);
        }
    }
}
