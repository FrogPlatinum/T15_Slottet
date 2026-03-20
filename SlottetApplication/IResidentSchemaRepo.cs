using Slottet.Domain.Enums.Entity;

namespace Slottet.Application
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
