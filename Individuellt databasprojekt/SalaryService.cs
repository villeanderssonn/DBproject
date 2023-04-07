using Individuellt_databasprojekt.Data;



namespace Individuellt_databasprojekt
{
    internal static class SalaryService
    {
        public static void SalaryInfo()
        {

            using (var context = new SchoolContext())
            {
                var courses = context.Courses.Select(c => new { c.Name, c.TeacherCourseSalary }).ToList();
                foreach (var course in courses)
                {
                    Console.WriteLine("Course: " + course.Name + ", Salary: " + course.TeacherCourseSalary);

                }
            }
        }

        public static void PrintAverageSalary()
        {
            using (var context = new SchoolContext())
            {
                var averageSalary = context.Courses.Average(c => c.TeacherCourseSalary);
                Console.WriteLine("The average salary across all courses is: " + averageSalary);


            }

        }
    }
}

