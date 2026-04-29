using Slottet.Blazor.Interfaces;
using Slottet.Shared.DTOs.ResidentSchema;

namespace Slottet.Blazor.Services
{
    public class ResidentSchemaService : IResidentSchemaService
    {
        private readonly HttpClient _httpClient;
        public ResidentSchemaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<ResidentSchemaDto> AddResidentSchemaAsync(CreateResidentSchemaDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteResidentSchemaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResidentSchemaDto[]> GetAllResidentSchemasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResidentSchemaDto> GetResidentSchemaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateResidentSchemaAsync(UpdateResidentSchemaDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
