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
            var createdResidentSchema = await repo.AddAsync(newResident);

            //Assert
            Assert.IsNotNull(createdResidentSchema);
            Assert.AreEqual(4, createdResidentSchema.Id);
            Assert.AreEqual("Karl Karlson", createdResidentSchema.Name);
            Assert.AreEqual(SlottetDomain.Enums.TrafficLightStatus.Yellow, createdResidentSchema.TrafficLight);
            Assert.IsNotNull(createdResidentSchema.MedicineStatuses);
            Assert.AreEqual("Hans Hansen", createdResidentSchema.Employee);
            Assert.AreEqual("Ny borger", createdResidentSchema.Note);
            //Find ud af teste nested classes, er medicinstatus id korrekt?
        }
        [TestMethod]
        public async Task UpdateAsync()
        {
            //Arrange: Setup resident schema and update it
            var repo = new ResidentSchemaMemoryRepo();

            var newResidentSchema = new ResidentSchema(
              id: 5,
              name: "Karl Karlson",
              trafficLight: SlottetDomain.Enums.TrafficLightStatus.Yellow,
              medicineStatuses: new List<MedicineStatus>
              {
                    new MedicineStatus { Id = 1, Time = DateTime.Now, Administered = true }
              },
              employee: "Hans Hansen",
              note: "Ny borger"
              );

            await repo.AddAsync(newResidentSchema);

            var updatedResidentSchema = new ResidentSchema(
            id: 5,
            name: "Niels Hansen Updated",
            trafficLight: SlottetDomain.Enums.TrafficLightStatus.Red,
            medicineStatuses: new List<MedicineStatus>
            {
            new MedicineStatus { Id = 1, Time = DateTime.Now, Administered = true }
             },
            employee: "Test Employee",
            note: "Opdateret note"
    );

            //Act

            await repo.UpdateAsync(updatedResidentSchema);

            //Assert
            Assert.IsNotNull(updatedResidentSchema);
            Assert.AreEqual(5, updatedResidentSchema.Id);
            Assert.AreEqual("Niels Hansen Updated", updatedResidentSchema.Name);
            Assert.AreEqual(SlottetDomain.Enums.TrafficLightStatus.Red, updatedResidentSchema.TrafficLight);
            Assert.IsNotNull(updatedResidentSchema.MedicineStatuses);
            Assert.AreEqual("Test Employee", updatedResidentSchema.Employee);
            Assert.AreEqual("Opdateret note", updatedResidentSchema.Note);
        }

        [TestMethod]
        public async Task DeleteAsync()
        {
            //Arrange: Setup resident schema and update it
            var repo = new ResidentSchemaMemoryRepo();

            var deletedResidentSchema = new ResidentSchema(
              id: 6,
              name: "Karl Karlson",
              trafficLight: SlottetDomain.Enums.TrafficLightStatus.Yellow,
              medicineStatuses: new List<MedicineStatus>
              {
                    new MedicineStatus { Id = 1, Time = DateTime.Now, Administered = true }
              },
              employee: "Hans Hansen",
              note: "Ny borger"
              );

            await repo.AddAsync(deletedResidentSchema);

            //Act
            await repo.DeleteAsync(6);

            //Assert
            
            var result = await repo.GetByIdAsync(6); //It only works when we call this line. Because of await/async?

            Assert.IsNull(result);
        }
    }

  }

