using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Reservations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.IsCancel).IsRequired();

            //builder.HasOne(r => r.FieldSituation)
            //    .WithOne(f => f.Reservation)
            //    .HasForeignKey(r => r.FieldSituationId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
