using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.FieldSituations
{
    public class FieldSituationConfiguration : IEntityTypeConfiguration<FieldSituation>
    {
        public void Configure(EntityTypeBuilder<FieldSituation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
            builder.Property(x => x.IsReserv).IsRequired();
            builder.Property(x => x.FootballFieldId).IsRequired();
            builder.Property(x => x.ReservationId).IsRequired();

            builder.HasOne(fs => fs.Reservation)
            .WithOne(r => r.FieldSituation)
            .HasForeignKey<Reservation>(r => r.FieldSituationId); // Reservation bağımlı olarak belirleniyor.
        }
    }
}
