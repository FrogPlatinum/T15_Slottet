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
            Assert.AreEqual(1, addedSchema.Id);
            Assert.AreEqual("name", addedSchema.Name);
            Assert.AreEqual(SlottetDomain.Enums.TrafficLightStatus.Red, addedSchema.TrafficLight);
            Assert.AreEqual(1, addedSchema.MedicineStatuses);
            Assert.AreEqual("Hans", addedSchema.Employee);
            Assert.AreEqual("Glad i dag", addedSchema.Note);

        }
    }
}
