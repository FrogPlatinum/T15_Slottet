using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlottetDomain.Entity;

namespace SlottetApplication
{
    public interface IResidentSchemaRepo
    {
        Task<ResidentSchema> GetByIdAsync(int id);
        Task<IEnumerable<ResidentSchema>> GetAllAsync();
        Task<ResidentSchema> AddAsync(ResidentSchema entity);
        Task UpdateAsync(ResidentSchema entity);
        Task DeleteAsync(int id);
    }
}
