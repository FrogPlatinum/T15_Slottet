using Slottet.Domain.Entity;

namespace Slottet.Application.Interfaces
{
    public interface IResidentSchemaRepo
    {
        Task<ResidentSchema> GetByIdAsync(int id);
        Task<IEnumerable<ResidentSchema>> GetAllAsync();
        Task<ResidentSchema> AddAsync(ResidentSchema entity);
        Task UpdateAsync(ResidentSchema entity);
        Task DeleteAsync(int id);
    }
}
