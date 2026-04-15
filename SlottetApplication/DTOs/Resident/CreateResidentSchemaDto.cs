using Slottet.Application.DTOs.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slottet.Application.DTOs.Resident
{
    public class CreateResidentSchemaDto
    {
        public string? Name { get; set; }
        public int TrafficLight { get; set; }
        public List<MedicineStatusDto> MedicineStatuses { get; set; } = new(); // Using MedicineStatusDto to represent the medicine statuses in the DTO, and initializing it to an empty list to avoid null reference issues.
        public string Employee { get; set; }
        public string? Note { get; set; }
    }
}
