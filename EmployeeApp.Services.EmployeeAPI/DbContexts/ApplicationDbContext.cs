using EmployeeApp.Services.EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Services.EmployeeAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Position>().HasData(
                new Position {
                PositionId = 1,
                Name = "Worker",
                BaseSalary = 15000
                },
                new Position
                {
                    PositionId = 2,
                    Name = "Director",
                    BaseSalary = 50000
                }
                );

            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   EmployeeId = 1,
                   PersonnelNumber = 11111,
                   FIO = "N.A.Ivanov",
                   DateOfBirth = new DateTime(1990,12, 21),
                   RegularOrExternal = false,
                   PositionId = 2
               },
               new Employee
               {
                    EmployeeId = 2,
                    PersonnelNumber = null,
                    FIO = "A.G.Petrov",
                    DateOfBirth = new DateTime(1985, 10, 25),
                    RegularOrExternal = true,
                    PositionId = 1
               }
               );

        }
    }
}
