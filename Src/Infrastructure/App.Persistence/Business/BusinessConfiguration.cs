using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace App.Persistence.Bussiness
{
    public class BusinessConfiguration : IEntityTypeConfiguration<Domain.Entities.Business>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Business> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Address).IsRequired().HasMaxLength(150);
            builder.Property(x => x.TownId).IsRequired();

            builder.HasOne(b => b.Town)
                .WithMany(t => t.Businesses)
                .HasForeignKey(b => b.TownId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade delete yerine Restrict kullanıyoruz.
        }
    }
}
