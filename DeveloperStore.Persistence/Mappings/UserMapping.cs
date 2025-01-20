using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DeveloperStore.Users.Domain.Entities;

namespace DeveloperStore.Persistence.Mappings
{
    public class UserMapping: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Phone)
                .HasMaxLength(20);

            builder.Property(u => u.Status)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(u => u.Role)
                .IsRequired()
                .HasConversion<string>();

            builder.HasOne(u => u.Address)
                .WithOne()
                .HasForeignKey<User>(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(u => u.Name, name => {
                name.Property(n => n.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired()
                    .HasMaxLength(50);

                name.Property(n => n.LastName)
                    .HasColumnName("LastName")
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
