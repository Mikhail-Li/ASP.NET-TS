using System;
using FluentValidation;
using Timesheets.Infrastructure.Constants;
using Timesheets.Models.Dto;
using Timesheets.Infrastructure.Extensions;

namespace Timesheets.Infrastructure.Validation
{
    public class InvoiceRequestValidator : AbstractValidator<InvoiceRequest>
    {
        public InvoiceRequestValidator()
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
