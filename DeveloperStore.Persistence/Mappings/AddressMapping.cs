using DeveloperStore.Users.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Persistence.Mappings
{
    public class AddressMapping: IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(a => a.Number)
                .IsRequired();

            builder.Property(a => a.ZipCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.OwnsOne(a => a.Geolocation, geo => {
                geo.Property(g => g.Latitude)
                    .HasColumnName("Latitude")
                    .IsRequired()
                    .HasMaxLength(20);

                geo.Property(g => g.Longitude)
                    .HasColumnName("Longitude")
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
