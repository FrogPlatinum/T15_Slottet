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
            var schema = await _databaseRepo.ResidentSchemas.FindAsync(id);
            if (schema != null)
            {
               _databaseRepo.ResidentSchemas.Remove(schema);
               await _databaseRepo.SaveChangesAsync();
            }
            
            return;
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
            var schemaUpdate = await _databaseRepo.ResidentSchemas.FindAsync(entity.Id);
            //if (schemaUpdate != null)
            //{
            //    schemaUpdate.Name = entity.Name;
            //    schemaUpdate.TrafficLight = entity.TrafficLight;
            //    schemaUpdate.MedicineStatuses = entity.MedicineStatuses;
            //    schemaUpdate.Employee = entity.Employee;
            //    schemaUpdate.Note = entity.Note;
            //}
            _databaseRepo.Entry(schemaUpdate).CurrentValues.SetValues(entity);
            //_databaseRepo.ResidentSchemas.Update(entity);
            await _databaseRepo.SaveChangesAsync(); 
            return;

        }
    }
}
