using SlottetDomain.Entity;
using SlottetInfrastructure;

namespace SlottetTests
{
    [TestClass]
    public sealed class ResidentTests
    {
        public ResidentSchemaMemoryRepo repo;

        [TestMethod]
        public void CreateResidentSchema()
        {
            //Arrange: add new ResidentSchema
            

        var newSchema = new ResidentSchema
            {
                Id = 1,
                Name = "name",
                TrafficLight = SlottetDomain.Enums.TrafficLightStatus.Red,
                MedicineStatuses = new List<MedicineStatus> { new MedicineStatus { Id = 1, Time = DateTime.Now.AddHours(-1), Administered = true } },
                Employee = "Hans",
                Note = "Glad i dag"

            };
            //Act

            repo.AddAsync(newSchema);

            //Assert
            Assert.AreEqual(4, repo._schemas.Count);

            var addedPerson = repo._schemas[0];
            Assert.AreEqual(1, newSchema.Id);
            Assert.AreEqual("name", newSchema.Name);
            Assert.AreEqual(SlottetDomain.Enums.TrafficLightStatus.Red, newSchema.TrafficLight);
            Assert.AreEqual(1, newSchema.MedicineStatuses.);
            Assert.AreEqual("Hans", newSchema.Employee);
            Assert.AreEqual("Glad i dag", newSchema.Note);

        }
    }
}
