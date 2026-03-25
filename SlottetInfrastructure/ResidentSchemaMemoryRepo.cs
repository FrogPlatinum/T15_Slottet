using Slottet.Application;
//using Slottet.Domain.Enums;
using Slottet.Domain.Entity;

namespace Slottet.Infrastructure
{
    public class ResidentSchemaMemoryRepo : IResidentSchemaRepo
    {
        private static List<ResidentSchema> _schemas = new List<ResidentSchema>
        {
            new ResidentSchema(
            id:1,
            name: "Niels Hansen",
            trafficLight: ResidentSchema.TrafficLightStatus.Green,
            medicineStatuses: new List<MedicineStatus>{new MedicineStatus { Time = DateTime.Now.AddHours(-1), Administered = true}},
            employee: "Lone Nielsen",
            note: "Morgenmedicin givet kl. 10:23"),

            new ResidentSchema(
            id:2,
            name: "Mette Jensen",
            trafficLight: ResidentSchema.TrafficLightStatus.Red,
            medicineStatuses: new List<MedicineStatus>{new MedicineStatus { Time = DateTime.Now.AddHours(-2), Administered = false }, new MedicineStatus { Time = DateTime.Now.AddMinutes(-30), Administered = false }},
            employee: "Peter Larsen",
            note: "Aftensmertestillende mangler - ring til familie"),

            new ResidentSchema(
            id:3,
            name: "Hans Pedersen",
            trafficLight: ResidentSchema.TrafficLightStatus.Yellow,
            medicineStatuses: new List<MedicineStatus>{new MedicineStatus { Time = DateTime.Now.AddHours(-3), Administered = true }, new MedicineStatus { Time = DateTime.Now.AddMinutes(-90), Administered = false }},
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
                existingSchema.MedicineStatuses = entity.MedicineStatuses;
                existingSchema.Employee = entity.Employee;
                existingSchema.Note = entity.Note;
            }
            return Task.CompletedTask;
        }
    }
}
