// Program.cs
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create the database if not exists
        using (var db = new AppDbContext())
        {
            db.Database.EnsureCreated();  // Ensures that the database is created if it doesn't exist

            // Seed some employee records if the table is empty
            if (!db.Employees.Any())
            {
                db.Employees.AddRange(
                    new Employee { FirstName = "John", LastName = "Doe", Position = "Software Engineer", Salary = 60000 },
                    new Employee { FirstName = "Jane", LastName = "Smith", Position = "Project Manager", Salary = 80000 },
                    new Employee { FirstName = "Sam", LastName = "Wilson", Position = "HR Manager", Salary = 55000 }
                );
                db.SaveChanges();
            }

            // Query and display all employees
            var employees = db.Employees.ToList();

            Console.WriteLine("Employees in the database:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"Id: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, Position: {employee.Position}, Salary: {employee.Salary:C}");
            }
        }
    }
}
