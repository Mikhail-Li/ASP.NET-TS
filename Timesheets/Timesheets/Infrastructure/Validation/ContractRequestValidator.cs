using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                .WithMessage(ValidationMessages.InvalidDateStart);

            RuleFor(x => x.DateEnd)
                .GreaterThanOrEqualTo(x => x.DateStart)
                .WithMessage(ValidationMessages.InvalidDateEnd);

        }
    }
}
