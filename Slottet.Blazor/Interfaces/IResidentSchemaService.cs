using Slottet.Shared.DTOs.ResidentSchema;

namespace Slottet.Blazor.Interfaces
{
    public interface IResidentSchemaService
    {
        Task<ResidentSchemaDto> GetResidentSchemaByIdAsync(int id);
        Task<ResidentSchemaDto[]> GetAllResidentSchemasAsync();
        Task<ResidentSchemaDto> AddResidentSchemaAsync(CreateResidentSchemaDto dto);
        Task UpdateResidentSchemaAsync(UpdateResidentSchemaDto dto);
        Task DeleteResidentSchemaAsync(int id);
    }
}
