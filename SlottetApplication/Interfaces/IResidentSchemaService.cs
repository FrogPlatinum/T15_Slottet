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
        Task<ResidentSchemaDto> AddResidentSchemaAsync(ResidentSchemaDto dto);
        Task<ResidentSchemaDto> UpdateResidentSchemaAsync(ResidentSchemaDto dto);
        Task DeleteResidentSchemaAsync(int id);
    }
}
