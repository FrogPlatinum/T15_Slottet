using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slottet.Application.DTOs.Medicine
{
    public class MedicineStatusDto
    {
        public DateTime Time { get; set; }
        public bool Administered { get; set; }
    }
}
