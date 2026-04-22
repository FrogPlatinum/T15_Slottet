using Slottet.Domain.Entity;
using Slottet.Shared;

namespace Slottet.Application
{
    public interface IResidentSchemaRepo
    {
        Task<ResidentSchemaDto> GetByIdAsync(int id);
        Task<ResidentSchemaDto[]> GetAllAsync();
        Task<ResidentSchema> AddAsync(ResidentSchema entity);
        Task UpdateAsync(ResidentSchema entity);
        Task DeleteAsync(int id);
    }
}
