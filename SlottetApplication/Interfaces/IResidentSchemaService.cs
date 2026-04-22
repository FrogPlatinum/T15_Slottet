using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slottet.Domain.Entity;
using Slottet.Shared;

namespace Slottet.Application.Interfaces
{
    public interface IResidentSchemaService
    {
        Task<ResidentSchemaDto> GetByIdAsync(int id);
        Task<IEnumerable<ResidentSchemaDto>> GetAllAsync();
        Task<ResidentSchemaDto> AddAsync(ResidentSchemaDto entity);
        Task UpdateAsync(ResidentSchemaDto entity);
        Task DeleteAsync(int id);
    }
}
