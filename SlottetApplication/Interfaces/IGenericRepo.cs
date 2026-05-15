using Slottet.Domain.Entity;

namespace Slottet.Application.Interfaces
{
    public interface IGenericRepo<T> where T : class 
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
