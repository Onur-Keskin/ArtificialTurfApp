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
            builder.Property(x => x.HourDuration).IsRequired();

            builder.HasOne(r => r.FootballField)
                .WithMany(f => f.Reservations)
                .HasForeignKey(r => r.FootballFieldId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
