using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlottetDomain.Enums;

namespace SlottetDomain.Entity
{
    public class ResidentSchema
    {
       

        public string? Name { get; set; }
        public TrafficLightStatus TrafficLight { get; set; }

        public List<MedicineStatus> MedicineStatuses { get; set; }

        public string Employee {  get; set; }

        public string Note {  get; set; }

        public ResidentSchema(string? name, TrafficLightStatus trafficLight, List<MedicineStatus> medicineStatuses, string employee, string note)
        {
            Name = name;
            TrafficLight = trafficLight;
            MedicineStatuses = medicineStatuses;
            Employee = employee;
            Note = note;
        }


    }
}
