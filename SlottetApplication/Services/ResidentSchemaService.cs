using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slottet.Application.Interfaces;
using Slottet.Shared;

namespace Slottet.Application.Services
{
    public class ResidentSchemaService : IResidentSchemaService
    {
        public Task<ResidentSchemaDto> AddAsync(ResidentSchemaDto entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResidentSchemaDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResidentSchemaDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ResidentSchemaDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
