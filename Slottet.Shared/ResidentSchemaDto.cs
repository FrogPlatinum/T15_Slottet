namespace Slottet.Shared
{
    public class ResidentSchemaDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public enum TrafficLightStatus // Does the DTO need this?
        {
            Green,
            Yellow,
            Red
        }
        public TrafficLightStatus TrafficLight { get; set; }

        public List<MedicineStatusDto> MedicineStatuses { get; set; }

        public string Employee { get; set; }

        public string Note { get; set; }

        
       // Do we need an empty constructor here?

    }
}
