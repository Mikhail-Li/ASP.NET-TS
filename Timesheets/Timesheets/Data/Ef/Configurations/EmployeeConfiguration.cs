using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Ef.Configurations
{
    public class EmployeeConfiguration:IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");

            builder
                .HasOne(employee => employee.User)
                .WithMany(user => user.Employee)
                .HasForeignKey("UserId");
        }
    }
}