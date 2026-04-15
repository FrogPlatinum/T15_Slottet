using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Slottet.Domain.Entity
{
    public class ResidentSchema
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public enum TrafficLightStatus
        {
            Green,
            Yellow,
            Red
        }
        public TrafficLightStatus TrafficLight { get; set; }

        public List<MedicineStatus>? MedicineStatuses { get; set; } = new(); // Made nullable and initialized to allow for cases where there might not be any medicine statuses, while still ensuring it is initialized to an empty list to avoid null reference issues.

        public string Employee {  get; set; } = string.Empty; // Added initialization to avoid null reference issues.

        public string? Note {  get; set; } // Made nullable to allow for cases where a note might not be provided.

        public ResidentSchema(int id, string? name, TrafficLightStatus trafficLight, List<MedicineStatus> medicineStatuses, string employee, string note)
        {
            Id = id;
            Name = name;
            TrafficLight = trafficLight;
            MedicineStatuses = medicineStatuses;
            Employee = employee;
            Note = note;
        }
        //Empty constructor for EF Core
        public ResidentSchema()
        {
            
        }

    }
}
