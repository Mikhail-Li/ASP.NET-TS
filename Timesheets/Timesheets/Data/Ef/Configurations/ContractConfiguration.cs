using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Ef.Configurations
{
    public class ContractConfiguration: IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("contracts");
            
            builder
                .HasOne(contract => contract.Client)
                .WithMany(client => client.Contracts)
                .HasForeignKey("ClientId");
        }
    }
}