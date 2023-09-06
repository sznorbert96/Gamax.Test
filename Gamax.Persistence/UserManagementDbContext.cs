using Gamax.Domain.Common;
using Gamax.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamax.Persistence
{
    public class UserManagementDbContext : DbContext
    {
        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserManagementDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public static class DbInitializer
        {
            public static void Initialize(UserManagementDbContext context)
            {
                context.Database.Migrate();
                var userGuid = Guid.Parse(Guid.NewGuid().ToString());
                // Seed adatok hozzáadása, például:
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new User
                    {
                        UserId = userGuid,
                        FirstName = "Test",
                        LastName = "Test",
                        BirthDate = DateTime.Parse("1996.03.08"),
                        Email = "test@gmail.com",
                        Password = "test",
                        CreatedBy = "Initializer",
                        CreatedDate = DateTime.UtcNow
                    }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
