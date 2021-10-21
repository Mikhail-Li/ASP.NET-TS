using FluentValidation;
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
                .WithMessage(ValidationMessages.Username);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(ValidationMessages.Password);

            RuleFor(x => x.Password.Length)
                .GreaterThanOrEqualTo(_minPasswordLength)
                .WithMessage(ValidationMessages.PasswordLength);

            RuleFor(x => x.Role)
                .NotEmpty()
                .WithMessage(ValidationMessages.Role);
        }
    }
}
