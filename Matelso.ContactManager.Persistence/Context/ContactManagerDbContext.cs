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
        public DbSet<Contact> Contact { get; set; }
    }
}
