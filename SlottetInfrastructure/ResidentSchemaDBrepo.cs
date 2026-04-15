using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Slottet.Application;
using Slottet.Domain.Entity;
using Slottet.Infrastructure.Data;

namespace Slottet.Infrastructure
{
    public class ResidentSchemaDBrepo : IResidentSchemaRepo
    {
        private AppDbContext _databaseRepo;

        public ResidentSchemaDBrepo(AppDbContext dbContext)
        {
            _databaseRepo = dbContext;
            
        }
        public async Task<ResidentSchema> AddAsync(ResidentSchema entity)
        {
            _databaseRepo.ResidentSchemas.Add(entity);
            await _databaseRepo.SaveChangesAsync();
            return entity;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResidentSchema>> GetAllAsync()
        {
           return await _databaseRepo.ResidentSchemas.ToListAsync();
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
