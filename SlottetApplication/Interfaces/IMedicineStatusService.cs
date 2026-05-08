using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slottet.Shared.DTOs.MedicinStatus;
using Slottet.Shared.DTOs.ResidentSchema;

namespace Slottet.Application.Interfaces
{
    public interface IMedicineStatusService
    {
        Task<MedicineStatusDto> GetMedicineStatusByIdAsync(int id);
        Task<MedicineStatusDto[]> GetAllMedicineStatusAsync();
        Task<MedicineStatusDto> AddMedicineStatusAsync(MedicineStatusDto dto);
        Task UpdateMedicineStatusAsync(MedicineStatusDto dto);
        Task DeleteMedicineStatusAsync(int id);
    }
}
