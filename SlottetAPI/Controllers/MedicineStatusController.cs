using Microsoft.AspNetCore.Mvc;
using Slottet.Application.Interfaces;
using Slottet.Infrastructure;
using Slottet.Shared.DTOs.MedicinStatus;
using Slottet.Shared.DTOs.ResidentSchema;

namespace Slottet.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MedicineStatusController : Controller
    {
        private readonly IMedicineStatusService _medicineStatusRepo;

        public MedicineStatusController(IMedicineStatusService medicineStatusDto)
        {
            _medicineStatusRepo = medicineStatusDto;
        }

        [HttpGet("allStatuses")]
        public async Task<IActionResult> GetAll()
        {
            var residents = await _medicineStatusRepo.GetAllMedicineStatusAsync();
            return Ok(residents);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resident = await _medicineStatusRepo.GetMedicineStatusByIdAsync(id);
            return Ok(resident);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(MedicineStatusDto medicineStatus)
        {
            await _medicineStatusRepo.AddMedicineStatusAsync(medicineStatus);
            return Ok();
        }

        [HttpPut("{id}")] //To do
        public async Task<IActionResult> UpdateAsync(int id, MedicineStatusDto entity)
        {
            entity.Id = id;
            await _medicineStatusRepo.UpdateMedicineStatusAsync(entity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _medicineStatusRepo.DeleteMedicineStatusAsync(id);
            return Ok();
        }

    }
}

