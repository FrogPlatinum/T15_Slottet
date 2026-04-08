using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slottet.Application;
using Slottet.Domain.Entity;
using Slottet.Infrastructure.Data;

namespace Slottet.Infrastructure
{
    public class ResidentSchemaDBrepo : IResidentSchemaRepo
    {
        private AppDbContext _databaseRepo;
        private List<ResidentSchema> _residentSchemas;

        public ResidentSchemaDBrepo(AppDbContext dbContext)
        {
            _databaseRepo = dbContext;
            _residentSchemas = _databaseRepo.ResidentSchemas.ToList();
        }
        public Task<ResidentSchema> AddAsync(ResidentSchema entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResidentSchema>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResidentSchema> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ResidentSchema entity)
        {
            throw new NotImplementedException();
        }
    }
}
