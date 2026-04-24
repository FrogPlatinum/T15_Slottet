using Microsoft.AspNetCore.Mvc;
using Slottet.Application.Interfaces;
using Slottet.Shared.DTOs.ResidentSchema;

namespace Slottet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResidentSchemaController : Controller
    {
        private readonly IResidentSchemaService _residentSchemaRepo;

        public ResidentSchemaController(IResidentSchemaService residentRepoDto)
        {
            _residentSchemaRepo = residentRepoDto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var residents = await _residentSchemaRepo.GetAllResidentSchemasAsync();
            return Ok(residents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resident = await _residentSchemaRepo.GetResidentSchemaByIdAsync(id);
            return Ok(resident);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateResidentSchemaDto residentSchema)
        {
            await _residentSchemaRepo.AddResidentSchemaAsync(residentSchema);
            return Ok();
        }

        [HttpPut("{id}")] //To do
        public async Task<IActionResult> UpdateAsync(int id, UpdateResidentSchemaDto entity)
        {
            //if(id != entity.Id) return BadRequest("Inkorrekt id");
            //    await _residentSchemaRepo.UpdateAsync(entity);
            //return Ok(entity);

            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _residentSchemaRepo.DeleteResidentSchemaAsync(id);
            return Ok();
        }

    }
}
