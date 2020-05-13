using core.Domain.People.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace core.Data
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(40)")
                .IsRequired();

            builder.Property(c => c.DateOfBirth)
                .HasColumnType("datetime")
                .IsRequired();

            builder.ToTable("Person");
        }
    }
}