using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slottet.Domain.Entity;
using Slottet.Shared.DTOs.ResidentSchema;

namespace Slottet.Application.Interfaces
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
