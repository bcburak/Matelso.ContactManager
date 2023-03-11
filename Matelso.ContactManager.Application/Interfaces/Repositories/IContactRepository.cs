using Matelso.ContactManager.Domain.Entities;

namespace Matelso.ContactManager.Application.Interfaces.Repositories
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        Task<bool> CheckEmailIsUnique(string email);
    }
}
