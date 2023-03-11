using Matelso.ContactManager.Application.Interfaces.Repositories;
using Matelso.ContactManager.Persistence.Context;
using Matelso.ContactManager.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Matelso.ContactManager.Persistence.Registration
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services, IConfiguration? configuration = null)
        {
            services.AddTransient<ContactManagerDbContext>();
            services.AddTransient<IContactRepository, ContactRepository>();
        }
    }
}
