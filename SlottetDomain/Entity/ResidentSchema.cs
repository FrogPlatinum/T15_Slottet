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

    }
}
