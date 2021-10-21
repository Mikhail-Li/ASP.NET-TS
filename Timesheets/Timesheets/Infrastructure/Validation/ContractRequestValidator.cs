using FluentValidation;
using System;
using Timesheets.Infrastructure.Constants;
using Timesheets.Infrastructure.Extensions;
using Timesheets.Models.Dto;

namespace Timesheets.Infrastructure.Validation
{
    public class ContractRequestValidator : AbstractValidator<ContractRequest>
    {
        public ContractRequestValidator()
        {
            RuleFor(x => x.DateStart)
                .InclusiveBetween(DateTimeExtensions.Epoch, DateTime.UtcNow)
                .WithMessage(ValidationMessages.DateStart);

            RuleFor(x => x.DateEnd)
                .GreaterThanOrEqualTo(x => x.DateStart)
                .WithMessage(ValidationMessages.DateEnd);
        }
    }
}
