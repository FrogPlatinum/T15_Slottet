using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ResidentSchemaDto> AddResidentSchemaAsync(ResidentSchemaDto dto)
        {
            var entity = new ResidentSchema
            {
                Name = dto.Name,
                TrafficLight = (Domain.Enums.TrafficLightStatus)dto.TrafficLight,
                Employee = dto.Employee,
                Note = dto.Note,
            };
            await _repo.AddAsync(entity);

            return new ResidentSchemaDto
            {
                Id = dto.Id,
                Name = dto.Name,
                TrafficLight = dto.TrafficLight,
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
                    TrafficLight = (ResidentSchemaDto.TrafficLightStatus)entity.TrafficLight,
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
                TrafficLight = (ResidentSchemaDto.TrafficLightStatus)entity.TrafficLight,
                Employee = entity.Employee,
                Note = entity.Note,
            };
        }
        //To do
        public async Task<ResidentSchemaDto> UpdateResidentSchemaAsync(ResidentSchemaDto dto)
        {
            //var entity = new ResidentSchema
            //{
            //    Name = dto.Name,
            //    TrafficLight = dto.TrafficLight,
            //    Employee = dto.Employee,
            //    Note = dto.Note,
            //};
            //await _repo.UpdateAsync(entity);

            //return new ResidentSchemaDto
            //{
            //    Name = dto.Name,
            //    TrafficLight = dto.TrafficLight,
            //    Employee = dto.Employee,
            //    Note = dto.Note,
            //};

            var schema = await _repo.GetByIdAsync(dto.Id);

            if (schema == null)
            {
                throw new KeyNotFoundException("fandt ikke borger");

            }

                    
                    schema.Name = dto.Name;
                    schema.TrafficLight = (Domain.Enums.TrafficLightStatus)dto.TrafficLight;
                    schema.Employee = dto.Employee;
                    schema.Note = dto.Note;

                    await _repo.UpdateAsync(schema);

            return new ResidentSchemaDto
            {
                Id = dto.Id,
                Name = dto.Name,
                TrafficLight = dto.TrafficLight,
                Employee = dto.Employee,
                Note = dto.Note,
            };
                
            

                
        }
    }
}
