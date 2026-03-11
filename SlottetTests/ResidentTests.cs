using SlottetDomain.Entity;
using SlottetInfrastructure;

namespace SlottetTests
{
    [TestClass]
    public sealed class ResidentTests
    {
        [TestMethod]
        public async Task AddAsync()
        {
            //Arrange: add new ResidentSchema
            var repo = new ResidentSchemaMemoryRepo();

            var newResident = new ResidentSchema(
                id: 4,
                name: "Karl Karlson",
                trafficLight: SlottetDomain.Enums.TrafficLightStatus.Yellow,
                medicineStatuses: new List<MedicineStatus>
                {
                    new MedicineStatus { Id = 1, Time = DateTime.Now, Administered = true }
                },
                employee: "Hans Hansen",
                note: "Ny borger"
                );

            //Act
            var createdResident = await repo.AddAsync(newResident);

            //Assert
            Assert.IsNotNull(createdResident);
            Assert.AreEqual(4, createdResident.Id);
            Assert.AreEqual("Karl Karlson", createdResident.Name);
            Assert.AreEqual(SlottetDomain.Enums.TrafficLightStatus.Yellow, createdResident.TrafficLight);
            Assert.IsNotNull(createdResident.MedicineStatuses);
            Assert.AreEqual("Hans Hansen", createdResident.Employee);
            Assert.AreEqual("Ny borger", createdResident.Note);
            //Find ud af teste nested classes, er medicinstatus id korrekt?
        }
    }
}
