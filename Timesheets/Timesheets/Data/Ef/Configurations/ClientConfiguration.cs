using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Ef.Configurations
{
    public class ClientConfiguration: IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("clients");

            builder
               .HasOne(client => client.User)
               .WithMany(user => user.Client)
               .HasForeignKey("UserId");
        }
    }
}