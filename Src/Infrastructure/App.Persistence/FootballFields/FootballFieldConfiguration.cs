using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.FootballFields
{
    public class FootballFieldConfiguration : IEntityTypeConfiguration<FootballField>
    {
        public void Configure(EntityTypeBuilder<FootballField> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.HourlyPricePerPerson).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.BusinessId).IsRequired();
        }
    }
}
