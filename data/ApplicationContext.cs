using Microsoft.EntityFrameworkCore;
using serviceTestTassk.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace serviceTestTassk.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; } = null!;
        public DbSet<Equipment> Equipments { get; set; } = null!;
        public DbSet<Contract> Contracts { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var building1 = new Building { Id = 1, Code = Guid.NewGuid().ToString(), Name = "Building1", MaxArea = 3705 };
            var building2 = new Building { Id = 2, Code = Guid.NewGuid().ToString(), Name = "Building2", MaxArea = 4165 };
            var building3 = new Building { Id = 3, Code = Guid.NewGuid().ToString(), Name = "Building3", MaxArea = 2497 };

            var equipment1 = new Equipment { Id = 1, Code = Guid.NewGuid().ToString(), Name = "Equipment1", Area = 594 };
            var equipment2 = new Equipment { Id = 2, Code = Guid.NewGuid().ToString(), Name = "Equipment2", Area = 526 };
            var equipment3 = new Equipment { Id = 3, Code = Guid.NewGuid().ToString(), Name = "Equipment3", Area = 634 };
            var equipment4 = new Equipment { Id = 4, Code = Guid.NewGuid().ToString(), Name = "Equipment4", Area = 879 };
            var equipment5 = new Equipment { Id = 5, Code = Guid.NewGuid().ToString(), Name = "Equipment5", Area = 521 };
            var equipment6 = new Equipment { Id = 6, Code = Guid.NewGuid().ToString(), Name = "Equipment6", Area = 602 };
            var equipment7 = new Equipment { Id = 7, Code = Guid.NewGuid().ToString(), Name = "Equipment7", Area = 113 };
            var equipment8 = new Equipment { Id = 8, Code = Guid.NewGuid().ToString(), Name = "Equipment8", Area = 976 };
            var equipment9 = new Equipment { Id = 9, Code = Guid.NewGuid().ToString(), Name = "Equipment9", Area = 357 };

            var contract = new Contract { Id = 1, BuildingId = building1.Id, EquipmentId = equipment1.Id, CountEquipment = 6 };

            modelBuilder.Entity<Building>().HasData(new Building[] { building1, building2, building3 });

            modelBuilder.Entity<Equipment>().HasData(new Equipment[] { equipment1, equipment2, equipment3,
                equipment4, equipment5, equipment6, equipment7, equipment8, equipment9});

            modelBuilder.Entity<Contract>().HasData(new Contract[] { contract });

            base.OnModelCreating(modelBuilder);
        }
    }
}
