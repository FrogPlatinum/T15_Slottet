using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slottet.Domain.Entity;
using Slottet.Domain.Enums;

namespace Slottet.Shared.DTOs.ResidentSchema
{
    public class CreateResidentSchemaDto
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }
        public TrafficLightStatus TrafficLight { get; set; }
        public List<MedicineStatus> MedicineStatuses { get; set; }
        public string? Employee { get; set; }
        public string? Note { get; set; }
    }
}
