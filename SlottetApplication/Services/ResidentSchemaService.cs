using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slottet.Application.Interfaces;
using Slottet.Domain.Entity;
using Slottet.Shared.DTOs.ResidentSchema;

namespace Slottet.Application.Services
{
    public class ResidentSchemaService : IResidentSchemaService
    {
        private readonly IResidentSchemaRepo _repo;
        public ResidentSchemaService(IResidentSchemaRepo repo)
        {
            _repo = repo;
        }
        public async Task<ResidentSchemaDto> AddResidentSchemaAsync(CreateResidentSchemaDto dto)
        {
            var entity = new ResidentSchema
            {
                Name = dto.Name,
                TrafficLight = dto.TrafficLight,
                MedicineStatuses = dto.MedicineStatuses,
                Employee = dto.Employee,
                Note = dto.Note,
            };
            await _repo.AddAsync(entity);

            return new ResidentSchemaDto
            {
                Name = dto.Name,
                TrafficLight = dto.TrafficLight,
                MedicineStatuses = dto.MedicineStatuses,
                Employee = dto.Employee,
                Note = dto.Note,
            };
        }

        public async Task DeleteResidentSchemaAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        //Test method - Check if works
        public async Task<ResidentSchemaDto[]> GetAllResidentSchemasAsync()
        {
            var entities = await _repo.GetAllAsync();
            var dtos = new List<ResidentSchemaDto>();

            foreach (var entity in entities)
            {
                dtos.Add(new ResidentSchemaDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    TrafficLight = entity.TrafficLight,
                    MedicineStatuses = entity.MedicineStatuses,
                    Employee = entity.Employee,
                    Note = entity.Note,
                });
            }
            return dtos.ToArray();
        }

        public async Task<ResidentSchemaDto> GetResidentSchemaByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return null;

            return new ResidentSchemaDto
            {
                Id = entity.Id,
                Name = entity.Name,
                TrafficLight = entity.TrafficLight,
                MedicineStatuses = entity.MedicineStatuses,
                Employee = entity.Employee,
                Note = entity.Note,
            };
        }
        //To do
        public async Task UpdateResidentSchemaAsync(UpdateResidentSchemaDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
