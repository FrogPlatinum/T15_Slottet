using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Slottet.Domain.Entity;
using SlottetDomain.Enums;

namespace Slottet.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        //Entities for tables
        public DbSet<ResidentSchema> ResidentSchemas => Set<ResidentSchema>();
        public DbSet<MedicineStatus> MedicineStatuses => Set<MedicineStatus>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relationship
            modelBuilder.Entity<ResidentSchema>()
                .HasMany(r => r.MedicineStatuses)
                .WithOne(m => m.ResidentSchema)
                .HasForeignKey(m => m.ResidentSchemaId)
                .IsRequired();

            //Seeding
            modelBuilder.Entity<ResidentSchema>().HasData(
                new ResidentSchema { Id = 1, Name = "Janne", TrafficLight = TrafficLightStatus.Yellow, Employee = "Susanne", Note = "..." });

            modelBuilder.Entity<MedicineStatus>().HasData(
                new MedicineStatus { Id = 1, Time = new DateTime(2026, 3, 27, 11, 0, 0), Administered = true, ResidentSchemaId = 1 });

        }
    }
}
