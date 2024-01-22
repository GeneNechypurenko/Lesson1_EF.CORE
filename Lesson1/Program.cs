using Microsoft.EntityFrameworkCore;
using System;

namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (AppContext appContext = new AppContext())
            {
                appContext.Database.EnsureCreated();
            }

            using (AppContext appContext = new AppContext())
            {
                var newUser = new User
                {
                    FirstName = "John",
                    LastName = "Travolta",
                    Email = "travolta@hollywood.com"
                };

                appContext.Users.Add(newUser);
                appContext.SaveChanges();
            }

            using (AppContext appContext = new AppContext())
            {
                foreach (var user in appContext.Users)
                {
                    Console.WriteLine($"Id: {user.Id}, First Name: {user.FirstName}, Last Name: {user.LastName}, Email: {user.Email}");
                }
            }
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Users;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}

//Scaffold-DbContext "Server=localhost;Database=Academy;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer