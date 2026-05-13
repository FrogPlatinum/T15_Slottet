using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slottet.Application.Interfaces;
using Slottet.Domain.Entity;
using Slottet.Shared.DTOs.MedicinStatus;
using Slottet.Shared.DTOs.ResidentSchema;

namespace Slottet.Application.Services
{
    public class MedicineStatusService : IMedicineStatusService
    {
        private readonly IMedicineStatusRepo _repo;
        public MedicineStatusService(IMedicineStatusRepo repo)
        {
            _repo = repo;
        }
        public async Task<MedicineStatusDto> AddMedicineStatusAsync(MedicineStatusDto dto)
        {
            var entity = new MedicineStatus
            {
                Time = dto.Time,
                Administered = dto.Administered,
                ResidentSchemaId = dto.ResidentSchemaId
               
            };
            await _repo.AddAsync(entity);

            return new MedicineStatusDto
            {
                Time = dto.Time,
                Administered = dto.Administered,
                ResidentSchemaId = dto.ResidentSchemaId
            };
        }

        public async Task DeleteMedicineStatusAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        //Test method - Check if works
        public async Task<MedicineStatusDto[]> GetAllMedicineStatusAsync()
        {
            var entities = await _repo.GetAllAsync();
            var dtos = new List<MedicineStatusDto>();

            foreach (var entity in entities)
            {
                dtos.Add(new MedicineStatusDto
                {
                    Id = entity.Id,
                    Time = entity.Time,
                    Administered = entity.Administered,
                    ResidentSchemaId = entity.ResidentSchemaId
                });
            }
            return dtos.ToArray();
        }

        public async Task<MedicineStatusDto> GetMedicineStatusByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return null;

            return new MedicineStatusDto
            {
                Id = entity.Id,
                Time = entity.Time,
                Administered = entity.Administered,
                ResidentSchemaId = entity.ResidentSchemaId
            };
        }
        //To do
        public async Task UpdateMedicineStatusAsync(MedicineStatusDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
