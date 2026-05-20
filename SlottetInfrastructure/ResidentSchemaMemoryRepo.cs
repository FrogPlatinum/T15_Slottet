using Slottet.Application.Interfaces;
using Slottet.Domain.Entity;
using Slottet.Domain.Enums;

namespace Slottet.Infrastructure
{
    public class ResidentSchemaMemoryRepo : IGenericRepo<ResidentSchema>
    {
        private static List<ResidentSchema> _schemas = new List<ResidentSchema>
        {
            new ResidentSchema(
            id:1,
            name: "Niels Hansen",
            trafficLight: TrafficLightStatus.Grøn,
            employee: "Lone Nielsen",
            note: "Morgenmedicin givet kl. 10:23"),

            new ResidentSchema(
            id:2,
            name: "Mette Jensen",
            trafficLight: TrafficLightStatus.Rød,
            employee: "Lone Nielsen",
            note: "Aftensmertestillende mangler - ring til familie"),

            new ResidentSchema(
            id:3,
            name: "Hans Pedersen",
            trafficLight: TrafficLightStatus.Gul,
            employee: "Anne Sørensen",
            note: "Blodtrykspille givet 1,5 time for sent")
        };
        public Task<ResidentSchema> AddAsync(ResidentSchema entity)
        {
            _schemas.Add(entity);
            return Task.FromResult(entity);
        }

        public Task DeleteAsync(int id)
        {
            var schema = _schemas.FirstOrDefault(x => x.Id == id);
            if (schema != null)
            {
                _schemas.Remove(schema);
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ResidentSchema>> GetAllAsync()
        {
            return Task.FromResult(_schemas.AsEnumerable());
        }

        public Task<ResidentSchema> GetByIdAsync(int id)
        {
            var schema = _schemas.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(schema);
        }

        public Task UpdateAsync(ResidentSchema entity)
        {
            var existingSchema = _schemas.FirstOrDefault(x =>x.Id == entity.Id);
            if (existingSchema != null)
            {
                existingSchema.Name = entity.Name;
                existingSchema.TrafficLight = entity.TrafficLight;
                existingSchema.Employee = entity.Employee;
                existingSchema.Note = entity.Note;
            }
            return Task.CompletedTask;
        }
    }
}
