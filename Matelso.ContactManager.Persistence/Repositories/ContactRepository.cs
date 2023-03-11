using Matelso.ContactManager.Application.Interfaces.Repositories;
using Matelso.ContactManager.Domain.Entities;
using Matelso.ContactManager.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Matelso.ContactManager.Persistence.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {

        private readonly ContactManagerDbContext _dbContext;
        public ContactRepository(ContactManagerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckEmailIsUnique(string email)
        {
            var result = await _dbContext.Contact.SingleOrDefaultAsync(i => i.Email.Equals(email));
            return (result != null) ? false : true;
        }

    }
}
