using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
