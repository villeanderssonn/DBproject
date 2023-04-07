using Individuellt_databasprojekt.Data;
using Individuellt_databasprojekt.Models;

namespace Individuellt_databasprojekt
{
    internal static class PersonnelService
    {
        public static void PersonnelInfo()
        {
            using (var context = new SchoolContext())
            {
                var personnels = context.Personnel.Select(c => new { c.Name, c.Position, c.RegisterDate, c.Course }).ToList();
                foreach (var personnel in personnels)
                {
                    Console.WriteLine("Name: " + personnel.Name + ", Position: " + personnel.Position + ", Register Date: " + personnel.RegisterDate + ", Course: " + personnel.Course);

                }

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Would you like to add a teacher to the database? Press 1 for yes and any other key for no.");


                var userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Console.Clear();
                    AddPersonnel();
                }
            }
        }

        public static void AddPersonnel()
        {
            using (var context = new SchoolContext())
            {
                Console.WriteLine("Enter the name of the personnel:");
                var name = Console.ReadLine();

                Console.WriteLine("Enter the position of the personnel:");
                var position = Console.ReadLine();

                var maxId = context.Personnel.Max(p => p.Id);
                var newId = maxId + 1;

                var newPersonnel = new Personnel { Id = newId, Name = name, Position = position, RegisterDate = DateTime.Now };
                context.Personnel.Add(newPersonnel);
                context.SaveChanges();
                Console.WriteLine("The personnel has been added successfully.");
            }
        }
    }
}
