using System;
using FluentValidation;
using Timesheets.Infrastructure.Constants;
using Timesheets.Models.Dto;
using Timesheets.Infrastructure.Extensions;

namespace Timesheets.Infrastructure.Validation
{
    public class SheetRequestValidator : AbstractValidator<SheetRequest>
    {
        public SheetRequestValidator()
        {
            RuleFor(x => x.Amount)
                .InclusiveBetween(1, 8)
                .WithMessage(ValidationMessages.SheetAmount);

            RuleFor(x => x.Date)
                .InclusiveBetween(DateTimeExtensions.Epoch, DateTime.UtcNow)
                .WithMessage(ValidationMessages.SheetDate);
        }
    }
}