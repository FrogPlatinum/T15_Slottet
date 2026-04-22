using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Slottet.Application;
using Slottet.Domain.Entity;
using Slottet.Infrastructure.Data;
using Slottet.Shared;


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

        public async Task UpdateAsync(ResidentSchema entity)
        {
            _databaseRepo.ResidentSchemas.Update(entity);
            await _databaseRepo.SaveChangesAsync();
        }

        public async Task<ResidentSchemaDto> GetByIdAsync(int id)
        {
            return await _databaseRepo.ResidentSchemas
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(r => new ResidentSchemaDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    TrafficLight = r.TrafficLight,
                    MedicineStatuses = r.MedicineStatuses,
                    Employee = r.Employee,
                    Note = r.Note,

                })
                
        }

        public async Task<ResidentSchemaDto[]> IResidentSchemaRepo.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
