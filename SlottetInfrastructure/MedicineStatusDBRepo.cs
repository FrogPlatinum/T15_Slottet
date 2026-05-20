using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Slottet.Application.Interfaces;
using Slottet.Domain.Entity;
using Slottet.Infrastructure.Data;

namespace Slottet.Infrastructure
{
    public class MedicineStatusDBRepo : IGenericRepo<MedicineStatus>
    {
        private AppDbContext _databaseRepo;

        public MedicineStatusDBRepo(AppDbContext dbContext)
        {
            _databaseRepo = dbContext;

        }
        public async Task<MedicineStatus> AddAsync(MedicineStatus entity)
        {
            _databaseRepo.MedicineStatuses.Add(entity);
            await _databaseRepo.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var status = await _databaseRepo.MedicineStatuses.FindAsync(id);
            if (status != null)
            {
                _databaseRepo.MedicineStatuses.Remove(status);
                await _databaseRepo.SaveChangesAsync();
            }

            return;
        }

        public async Task<IEnumerable<MedicineStatus>> GetAllAsync()
        {
            return await _databaseRepo.MedicineStatuses.ToListAsync();
        }

        public async Task<MedicineStatus?> GetByIdAsync(int id)
        {
            return await _databaseRepo.MedicineStatuses.FindAsync(id);
        }

        public async Task UpdateAsync(MedicineStatus entity)
        {
            _databaseRepo.MedicineStatuses.Update(entity);
            await _databaseRepo.SaveChangesAsync();
            return;
        }
    }
}
