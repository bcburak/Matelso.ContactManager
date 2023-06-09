﻿namespace Matelso.ContactManager.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
