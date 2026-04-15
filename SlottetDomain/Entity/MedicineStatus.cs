using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Slottet.Domain.Entity
{
    public class MedicineStatus
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool Administered { get; set; }
        public int ResidentSchemaId { get; set; } // FK relationship to ResidentSchema.

        [JsonIgnore] // JsonIgnore attribute is used to prevent circular reference issues during JSON serialization. This is important because ResidentSchema likely has a collection of MedicineStatus, and without this attribute, it could lead to infinite recursion when serializing to JSON.
        public ResidentSchema? ResidentSchema { get; set; } // Navigation property to establish the relationship with ResidentSchema. This is necessary for EF Core to understand the relationship between the two entities and to enable navigation from MedicineStatus to its associated ResidentSchema.
    }
}
