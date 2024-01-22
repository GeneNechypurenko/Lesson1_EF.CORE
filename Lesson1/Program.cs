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

            //using (AcademyContext context = new AcademyContext())
            //{
            //    context.Database.EnsureCreated();
            //}

            //using (AcademyContext context = new AcademyContext())
            //{
            //    var newUser = new Teacher()
            //    {
            //        EmploymentDate = DateOnly.FromDateTime(DateTime.Today),
            //        Name = "Howard",
            //        Premium = 1000,
            //        Salary = 10000,
            //        Surname = "Earl"
            //    };

            //    context.Teachers.Add(newUser);
            //    context.SaveChanges();
            //}

            //using (AcademyContext context = new AcademyContext())
            //{
            //    foreach (var teacher in context.Teachers)
            //    {
            //        Console.WriteLine($"Id: {teacher.Id}, Employment Date: {teacher.EmploymentDate}, First Name: {teacher.Name}, Last Name: {teacher.Surname}, Premium: {teacher.Premium}, Salary: {teacher.Salary}");
            //    }
            //}

            //---------task3---------------------------------------------------------------------------------------------------------------

            using (AcademyContext context = new AcademyContext())
            {
                var updUser = context.Teachers.SingleOrDefault(e => e.Name.Equals("Howard"));

                if (updUser != null)
                {
                    updUser.EmploymentDate = DateOnly.FromDateTime(DateTime.Today);
                    updUser.Name = "Speedy";
                    updUser.Premium = 3000;
                    updUser.Salary = 1000000;
                    updUser.Surname = "Gonzales";

                    context.Update(updUser);
                    context.SaveChanges();
                }
            }

            using (AcademyContext context = new AcademyContext())
            {
                foreach (var teacher in context.Teachers)
                {
                    Console.WriteLine($"Id: {teacher.Id}, Employment Date: {teacher.EmploymentDate}, First Name: {teacher.Name}, Last Name: {teacher.Surname}, Premium: {teacher.Premium}, Salary: {teacher.Salary}");
                }
            }

            //---------task4---------------------------------------------------------------------------------------------------------------

            using (var context = new MenuContext())
            {
                context.Database.EnsureCreated();
            }

            using (var context = new MenuContext())
            {
                var dish = new Menu { DishName = "Burger", Price = 150 };
                context.Dishes.Add(dish);
                context.SaveChanges();

                var dishCollection = new List<Menu>
                {
                    new Menu { DishName = "Le Borsch", Price = 200 },
                    new Menu { DishName = "Hot Dogs", Price = 180 },
                    new Menu { DishName = "French Fries", Price = 120 }
                };

                context.Dishes.AddRange(dishCollection);
                context.SaveChanges();
            }

            using (var context = new MenuContext())
            {
                if (context.Database.CanConnect())
                {
                    var soupDishes = context.Dishes.Where(e => e.DishName.Contains("Borsch")).ToList();
                    var dishById = context.Dishes.Where(e => e.Id == 2);
                    var lastDish = context.Dishes.OrderByDescending(e => e.Id).FirstOrDefault();
                }
            }

        }
    }
    public class Menu
    {
        public int Id { get; set; }
        public string DishName { get; set; }
        public decimal Price { get; set; }
    }

    public class MenuContext : DbContext
    {
        public DbSet<Menu> Dishes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Menu;Trusted_Connection=True;TrustServerCertificate=True;");
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