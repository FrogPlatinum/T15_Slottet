using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slottet.Shared
{
    public class MedicineStatusDto
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool Administered { get; set; }
        public int ResidentSchemaId { get; set; }
    }
}
