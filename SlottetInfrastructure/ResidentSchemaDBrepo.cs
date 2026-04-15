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

        public async Task DeleteAsync(int id)
        {
            // Find the entity by id
            var entity = await _databaseRepo.ResidentSchemas.FindAsync(id);
            
            if (entity == null)
                return;

            _databaseRepo.ResidentSchemas.Remove(entity);
            await _databaseRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<ResidentSchema>> GetAllAsync()
        {
           return await _databaseRepo.ResidentSchemas.ToListAsync();
        }

        public async Task<ResidentSchema> GetByIdAsync(int id)
        {
            return await _databaseRepo.ResidentSchemas.FindAsync(id);
        }

        public async Task UpdateAsync(ResidentSchema entity)
        {
            var existingEntity = await _databaseRepo.ResidentSchemas.FindAsync(entity.Id);
            if (existingEntity == null)
                return;

            // Update the properties of the existing entity
            _databaseRepo.Entry(existingEntity).CurrentValues.SetValues(entity); // Entry and SetValues are EF Core methods to update the entity's properties
            await _databaseRepo.SaveChangesAsync();
        }
    }
}
