using SlottetDomain.Entity;

namespace SlottetTests
{
    [TestClass]
    public sealed class ResidentTests
    {
        [TestMethod]
        public void CreateResidentSchema()
        {
            //Arrange: add new ResidentSchema
            var newSchema = new ResidentSchema
            {
                Id = 1,
                Name = "name",
                TrafficLight = SlottetDomain.Enums.TrafficLightStatus.Red,
                MedicineStatuses = 1,
                Employee = "Hans",
                Note = "Glad i dag"

            };
            //Act

            ResidentSchemaRepo.Add(newSchema);

            //Assert
            Assert.AreEqual(1, ??.Schemas.Count);

            var addedPerson = ??.Schemas[0];
            Assert.AreEqual(1, newSchema.Id);
            Assert.AreEqual("name", newSchema.Name);
            Assert.AreEqual(SlottetDomain.Enums.TrafficLightStatus.Red, newSchema.TrafficLight);
            Assert.AreEqual(1, newSchema.MedicineStatuses);
            Assert.AreEqual("Hans", newSchema.Employee);
            Assert.AreEqual("Glad i dag", newSchema.Note);

        }
    }
}
