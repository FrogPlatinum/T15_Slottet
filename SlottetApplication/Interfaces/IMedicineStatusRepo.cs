using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slottet.Domain.Entity;

namespace Slottet.Application.Interfaces
{
    public interface IMedicineStatusRepo
    {
        Task<MedicineStatus> GetByIdAsync(int id);
        Task<IEnumerable<MedicineStatus>> GetAllAsync();
        Task<MedicineStatus> AddAsync(MedicineStatus entity);
        Task UpdateAsync(MedicineStatus entity);
        Task DeleteAsync(int id);
    }
}
