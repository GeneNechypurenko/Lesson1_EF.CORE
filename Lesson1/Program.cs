using Microsoft.EntityFrameworkCore;
using System;

namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //---------task1---------------------------------------------------------------------------------------------------------------

            //using (AppContext appContext = new AppContext())
            //{
            //    appContext.Database.EnsureCreated();
            //}

            //using (AppContext appContext = new AppContext())
            //{
            //    var newUser = new User
            //    {
            //        FirstName = "John",
            //        LastName = "Travolta",
            //        Email = "travolta@hollywood.com"
            //    };

            //    appContext.Users.Add(newUser);
            //    appContext.SaveChanges();
            //}

            //using (AppContext appContext = new AppContext())
            //{
            //    foreach (var user in appContext.Users)
            //    {
            //        Console.WriteLine($"Id: {user.Id}, First Name: {user.FirstName}, Last Name: {user.LastName}, Email: {user.Email}");
            //    }
            //}

            //---------task2---------------------------------------------------------------------------------------------------------------

            using (AcademyContext context = new AcademyContext())
            {
                context.Database.EnsureCreated();
            }

            using (AcademyContext context = new AcademyContext())
            {
                var newUser = new Teacher()
                {
                    EmploymentDate = DateOnly.FromDateTime(DateTime.Today),
                    Name = "Howard",
                    Premium = 1000,
                    Salary = 10000,
                    Surname = "Earl"
                };

                context.Teachers.Add(newUser);
                context.SaveChanges();
            }

            using (AcademyContext context = new AcademyContext())
            {
                foreach (var teacher in context.Teachers)
                {
                    Console.WriteLine($"Id: {teacher.Id}, Employment Date: {teacher.EmploymentDate}, First Name: {teacher.Name}, Last Name: {teacher.Surname}, Premium: {teacher.Premium}, Salary: {teacher.Salary}");
                }
            }
        }
    }

    //public class User
    //{
    //    public int Id { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Email { get; set; }
    //}

    //public class AppContext : DbContext
    //{
    //    public DbSet<User> Users { get; set; }
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseSqlServer("Server=localhost;Database=Users;Trusted_Connection=True;TrustServerCertificate=True;");
    //    }
    //}
}

//Scaffold-DbContext "Server=localhost;Database=Academy;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer