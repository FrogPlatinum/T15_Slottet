using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Slottet.Application;
using Slottet.Application.DTOs.Resident;
using Slottet.Domain.Entity;

namespace Slottet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResidentSchemaController : Controller
    {
        private readonly IResidentSchemaRepo _residentSchemaRepo;

        public ResidentSchemaController(IResidentSchemaRepo residentRepo)
        {
            _residentSchemaRepo = residentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var residents = await _residentSchemaRepo.GetAllAsync();
            return Ok(residents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resident = await _residentSchemaRepo.GetByIdAsync(id);
            return Ok(resident);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddAsync(ResidentSchema entity) // Changed from residentSchema to entity for consistency
        //{
        //    await _residentSchemaRepo.AddAsync(entity);
        //    return Ok();
        //}

        // DTO AddAsync to handle incoming data
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateResidentSchemaDto dto)
        {
            var entity = new ResidentSchema
            {
                Name = dto.Name,
                TrafficLight = (ResidentSchema.TrafficLightStatus)dto.TrafficLight,
                Employee = dto.Employee,
                Note = dto.Note,
                MedicineStatuses = dto.MedicineStatuses.Select(x => new MedicineStatus
                {
                    Time = x.Time,
                    Administered = x.Administered
                }).ToList()
            };

            await _residentSchemaRepo.AddAsync(entity);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(UpdateResidentSchemaDto dto)
        {
            var existing = await _residentSchemaRepo.GetByIdAsync(dto.Id);

            if (existing == null)
                return NotFound();

            // Update resident fields with DTO values
            existing.Name = dto.Name;
            existing.Employee = dto.Employee;
            existing.Note = dto.Note;
            existing.TrafficLight = (ResidentSchema.TrafficLightStatus)dto.TrafficLight;

            // Update medicine statuses by matching IDs
            foreach (var updatedStatus in dto.MedicineStatuses)
            {
                var existingStatus = existing.MedicineStatuses
                    .FirstOrDefault(x => x.Id == updatedStatus.Id);

                if (existingStatus != null)
                {
                    existingStatus.Administered = updatedStatus.Administered;
                }
            }

            await _residentSchemaRepo.UpdateAsync(existing);

            return Ok(existing);
        }


        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateAsync(int id, ResidentSchema entity)
        //{
        //    if(id != entity.Id) return BadRequest("Inkorrekt id");
        //        await _residentSchemaRepo.UpdateAsync(entity);
        //    return Ok(entity);
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _residentSchemaRepo.DeleteAsync(id);
            return Ok();
        }

    }
}
