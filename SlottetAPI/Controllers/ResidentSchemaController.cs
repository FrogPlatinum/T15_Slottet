using Microsoft.AspNetCore.Mvc;
using Slottet.Application;
using Slottet.Domain.Entity;
using Slottet.Shared;

namespace Slottet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResidentSchemaController : Controller
    {
        private readonly IResidentSchemaRepo _residentSchemaRepo;
        private readonly List<ResidentSchemaDto> schemaDtos;

        public ResidentSchemaController(IResidentSchemaRepo residentRepo)
        {
            _residentSchemaRepo = residentRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<ResidentSchemaDto>> GetAll()
        {
            //var residents = await _residentSchemaRepo.GetAllAsync();
            //return Ok(residents);
            var schemas = await _residentSchemaRepo.GetAllAsync().

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resident = await _residentSchemaRepo.GetByIdAsync(id);
            return Ok(resident);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ResidentSchema residentSchema)
        {
            await _residentSchemaRepo.AddAsync(residentSchema);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ResidentSchema entity)
        {
            if(id != entity.Id) return BadRequest("Inkorrekt id");
                await _residentSchemaRepo.UpdateAsync(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _residentSchemaRepo.DeleteAsync(id);
            return Ok();
        }

    }
}
