using System;

namespace Slottet.Shared;
public class ResidentSchemaDto
{
	public ResidentSchemaDto()
	{

    public string? Name { get; set; }
    public enum TrafficLightStatus
    {
        Green,
        Yellow,
        Red
    }
    public TrafficLightStatus TrafficLight { get; set; }

    public List<MedicineStatus> MedicineStatuses { get; set; }

    public string Employee { get; set; }

    public string Note { get; set; }
}

