using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.ValueObjects;

namespace Timesheets.Infrastructure.Extensions
{
    public class MoneyValueConverter : ValueConverter<Money, decimal>
    {
        public MoneyValueConverter(ConverterMappingHints mappingHints = null) : base(
            x => x.Amount,
            value => Money.FromDecimal(value),
            mappingHints
            )
        
        { }
    }
}
