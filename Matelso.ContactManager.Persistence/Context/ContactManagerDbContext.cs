using Matelso.ContactManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Matelso.ContactManager.Persistence.Context
{
    public class ContactManagerDbContext : DbContext, IDisposable
    {

        protected readonly IConfiguration Configuration;

        public ContactManagerDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContactManagerDbContext(DbContextOptions<ContactManagerDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseNpgsql(Configuration.GetConnectionString("ContactManagerDb"));

            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity entity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entity.LastChangeTimestamp = now;
                            break;
                        case EntityState.Added:
                            entity.CreationTimestamp = now;
                            entity.LastChangeTimestamp = now;
                            break;
                    }
                }
            }

            return await base.SaveChangesAsync();
        }
        public DbSet<Contact> Contact { get; set; }
    }
}
