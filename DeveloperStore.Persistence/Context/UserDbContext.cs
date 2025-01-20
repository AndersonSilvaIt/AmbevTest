using DeveloperStore.Users.Domain.Entities;
using DeveloperStore.Users.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Persistence.Context
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach(var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                             property.SetColumnType("varchar(100)");

            // TODO
            //foreach(var relationship in modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}