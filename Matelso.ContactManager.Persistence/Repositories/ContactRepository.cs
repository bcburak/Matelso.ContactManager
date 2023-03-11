using Matelso.ContactManager.Application.Interfaces.Repositories;
using Matelso.ContactManager.Domain.Entities;
using Matelso.ContactManager.Persistence.Context;

namespace Matelso.ContactManager.Persistence.Repositories
{
    internal class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(ContactManagerDbContext dbContext) : base(dbContext)
        {
        }

    }
}
