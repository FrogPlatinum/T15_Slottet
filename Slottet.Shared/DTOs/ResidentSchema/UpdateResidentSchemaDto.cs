using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slottet.Domain.Entity;
using Slottet.Domain.Enums;

namespace Slottet.Shared.DTOs.ResidentSchema
{
    public class UpdateResidentSchemaDto
    {
        public string? Name { get; set; }
        public TrafficLightStatus? TrafficLight { get; set; }
        public List<MedicineStatus>? MedicineStatuses { get; set; }
        public string? Employee { get; set; }
        public string? Note { get; set; }
    }
}
