using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slottet.Domain.Enums;


namespace Slottet.Domain.Entity
{
    public class ResidentSchema
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public TrafficLightStatus TrafficLight { get; set; }
        public List<MedicineStatus> MedicineStatuses { get; set; }
        public string? Employee {  get; set; }
        public string? Note {  get; set; }

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
