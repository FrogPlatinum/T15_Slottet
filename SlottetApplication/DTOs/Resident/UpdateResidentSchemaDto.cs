using Slottet.Application.DTOs.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slottet.Application.DTOs.Resident
{
    public class UpdateResidentSchemaDto
    {
        public int Id { get; set; } // Id is required to identify which resident schema to update.
        public string Name { get; set; }
        public int TrafficLight { get; set; }
        public List<UpdateMedicineStatusDto> MedicineStatuses { get; set; } = new();
        public string Employee { get; set; }
        public string? Note { get; set; }
        
    }
}
