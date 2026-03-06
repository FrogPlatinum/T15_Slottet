using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlottetDomain.Entity
{
    public class MedicineStatus
    {
        public DateTime Time { get; set; }
        public bool Administered { get; set; }
    }
}
