using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slottet.Domain.Enums.Entity
{
    public class MedicineStatus
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool Administered { get; set; }
    }
}
