using Slottet.Blazor.Interface;
using Slottet.Shared;

namespace Slottet.Blazor.Services
{
    public class ResidentSchemaService : IResidentSchemaService
    {
        private readonly HttpClient _http;
        public ResidentSchemaService(HttpClient http)
        {
            _http = http;
        }

        public Task<bool> CreateAsync(ResidentSchemaDto schemaDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResidentSchemaDto>> GetAllAsync()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<List<ResidentSchemaDto>>("residentSchema");
                return result ?? new List<ResidentSchemaDto>();
            }
            catch (HttpRequestException)
            {
                return new List<ResidentSchemaDto>();
            }
        }

        public Task<ResidentSchemaDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
