using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Entities;

namespace EmployeeManagementAPI.Context
{
    // Represents a session with the database
    // A bridge between Entity classes and the database tables
    public class EmployeeDbContext : DbContext
    {
        // DbSet<NameOfEntity> NameOfDbTable 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<EmployeeHistory> EmployeesHistory { get; set; }

        // Connection to DB when DbContext is registered
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {   
            //Database.EnsureCreated();
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Employee>().HasData(
        //         new Employee(){
        //             Id = 1,
        //             FirstName = "Aaa",
        //             LastName = "Bbb",
        //             Address = "Postova",
        //             DateOfBirth = "2001-04-12",
        //             PositionName = "Cook",
        //             Salary = 20 }, 
        //         new Employee(){
        //             Id = 2,
        //             FirstName = "Dedo",
        //             LastName = "Mraz",
        //             Address = "Postova",
        //             DateOfBirth = "1980-02-26",
        //             PositionName = "Waiter",
        //             Salary = 20 } 
        //         );

        //     modelBuilder.Entity<Position>().HasData(
        //         new Position(){
        //             Id = 1,
        //             Name = "Cook",
        //             Description = "Cooking"
        //         });

        //     modelBuilder.Entity<EmployeeHistory>().HasData(
        //         new EmployeeHistory(){
        //             Id = 1,
        //             EmployeeId = 2,
        //             FirstName = "Eduard",
        //             LastName = "Pipes",
        //             Address = "Postova",
        //             DateOfBirth = "2001-08-09",
        //             PositionName = "Cook",
        //             Salary = 20
        //         });
            


        //     base.OnModelCreating(modelBuilder);
        // }
    }
}