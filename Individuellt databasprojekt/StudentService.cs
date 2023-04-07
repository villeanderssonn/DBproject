using Individuellt_databasprojekt.Data;
using Individuellt_databasprojekt.Models;

namespace Individuellt_databasprojekt
{
    internal static class StudentService
    {


        public static void StudentInfo()
        {
            using (var context = new SchoolContext())
            {
                var students = context.Students.Select(s => new { s.Name, s.Class, s.PersonalNumber }).ToList();
                foreach (var student in students)
                {
                    Console.WriteLine("Name: " + student.Name + ", Class: " + student.Class + ", Personal Number: " + student.PersonalNumber);
                }
            }

        }

        public static void AddStudent()
        {
            Console.WriteLine("Would you like to add a student to the database? Press 1 for yes and any other key for no.");
            var userInput = Console.ReadLine();
            if (userInput == "1")
            {
                using (var context = new SchoolContext())
                {
                    Console.WriteLine("Enter the name of the student:");
                    var name = Console.ReadLine();

                    var maxId = context.Students.Max(s => s.Id);
                    var newId = maxId + 1;

                    Console.WriteLine("Enter the class for the student:");
                    var studentClass = Console.ReadLine();

                    Console.WriteLine("Enter the personal number for the student:");
                    var personalNumber = Console.ReadLine();

                    var newStudent = new Student { Id = newId, Name = name, Class = studentClass, PersonalNumber = personalNumber };
                    context.Students.Add(newStudent);

                    context.SaveChanges();
                    Console.WriteLine("The student has been added successfully with class: " + studentClass + " and personal number: " + personalNumber);
                }
            }
        }
    }
}
