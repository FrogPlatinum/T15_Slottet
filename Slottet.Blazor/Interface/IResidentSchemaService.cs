using Slottet.Shared;

namespace Slottet.Blazor.Interface
{
    public interface IResidentSchemaService
    {
        Task<List<ResidentSchemaDto>> GetAllAsync();
        Task<ResidentSchemaDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(ResidentSchemaDto schemaDto);
    }
}
