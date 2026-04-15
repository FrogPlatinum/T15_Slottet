using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Slottet.Domain.Entity;
using Slottet.Infrastructure;
using Slottet.Infrastructure.Data;

namespace SlottetTests
{
    [TestClass]
    public sealed class ResidentTests
    {
        private ResidentSchemaDBrepo _residentDBRepo;
        private AppDbContext _context;

        [TestInitialize]
        public void Init()
        {
            var config = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            _context = new AppDbContext(config);
            _context.Database.EnsureCreated();

            _residentDBRepo = new ResidentSchemaDBrepo(_context);
        }

        [TestMethod]
        public async Task AddAsync()
        {
            //Arrange: add new ResidentSchema
            var newResident = new ResidentSchema(
                id: 2,
                name: "Karl Karlson",
                trafficLight: ResidentSchema.TrafficLightStatus.Yellow,
                medicineStatuses: new List<MedicineStatus>
                {
                    new MedicineStatus { Id = 2, Time = DateTime.Now, Administered = true }
                },
                employee: "Hans Hansen",
                note: "Ny borger"
                );

            //Act
            var createdResidentSchema = await _residentDBRepo.AddAsync(newResident);

            //Assert
            Assert.IsNotNull(createdResidentSchema);
            Assert.AreEqual(2, createdResidentSchema.Id);
            Assert.AreEqual("Karl Karlson", createdResidentSchema.Name);
            Assert.AreEqual(ResidentSchema.TrafficLightStatus.Yellow, createdResidentSchema.TrafficLight);
            Assert.IsNotNull(createdResidentSchema.MedicineStatuses);
            Assert.AreEqual("Hans Hansen", createdResidentSchema.Employee);
            Assert.AreEqual("Ny borger", createdResidentSchema.Note);
            //Find ud af teste nested classes, er medicinstatus id korrekt?
        }
        [TestMethod]
        public async Task UpdateAsync()
        {
            //Arrange: Setup resident schema and update it
            var newResidentSchema = new ResidentSchema(
              id: 5,
              name: "Karl Karlson",
              trafficLight: ResidentSchema.TrafficLightStatus.Yellow,
              medicineStatuses: new List<MedicineStatus>
              {
                    new MedicineStatus { Id = 3, Time = DateTime.Now, Administered = true }
              },
              employee: "Hans Hansen",
              note: "Ny borger"
              );

            await _residentDBRepo.AddAsync(newResidentSchema);

            var updatedResidentSchema = new ResidentSchema(
            id: 5,
            name: "Niels Hansen Updated",
            trafficLight: ResidentSchema.TrafficLightStatus.Red,
            medicineStatuses: new List<MedicineStatus>
            {
            new MedicineStatus { Id = 1, Time = DateTime.Now, Administered = true }
             },
            employee: "Test Employee",
            note: "Opdateret note"
    );

            //Act

            await _residentDBRepo.UpdateAsync(updatedResidentSchema);

            //Assert
            Assert.IsNotNull(updatedResidentSchema);
            Assert.AreEqual(5, updatedResidentSchema.Id);
            Assert.AreEqual("Niels Hansen Updated", updatedResidentSchema.Name);
            Assert.AreEqual(ResidentSchema.TrafficLightStatus.Red, updatedResidentSchema.TrafficLight);
            Assert.IsNotNull(updatedResidentSchema.MedicineStatuses);
            Assert.AreEqual("Test Employee", updatedResidentSchema.Employee);
            Assert.AreEqual("Opdateret note", updatedResidentSchema.Note);
        }

        [TestMethod]
        public async Task DeleteAsync()
        {
            //Arrange: Setup resident schema and update it

            var deletedResidentSchema = new ResidentSchema(
              id: 6,
              name: "Karl Karlson",
              trafficLight: ResidentSchema.TrafficLightStatus.Yellow,
              medicineStatuses: new List<MedicineStatus>
              {
                    new MedicineStatus { Id = 3, Time = DateTime.Now, Administered = true }
              },
              employee: "Hans Hansen",
              note: "Ny borger"
              );

            await _residentDBRepo.AddAsync(deletedResidentSchema);

            //Act
            await _residentDBRepo.DeleteAsync(6);

            //Assert
            var result = await _residentDBRepo.GetByIdAsync(6); //It only works when we call this line. Because of await/async?
            Assert.IsNull(result);
        }
    }

  }

