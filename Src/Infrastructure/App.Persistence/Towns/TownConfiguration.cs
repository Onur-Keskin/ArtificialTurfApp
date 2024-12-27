using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Towns
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TownName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.CityId).IsRequired();
        }
    }
}
