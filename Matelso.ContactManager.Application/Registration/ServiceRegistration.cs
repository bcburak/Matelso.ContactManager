using Matelso.ContactManager.Application.Interfaces.Services;
using Matelso.ContactManager.Application.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Matelso.ContactManager.Application.Registration
{
    public static class ServiceRegistration
    {

        public static void AddApplicationRegistration(this IServiceCollection services)
        {

            services.AddScoped<IContactManagerService, ContactManagerService>();
            //services.AddScoped<ContactValidator>();

        }
    }
}
