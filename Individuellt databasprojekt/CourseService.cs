using Individuellt_databasprojekt.Data;


namespace Individuellt_databasprojekt
{
    internal static class CourseService
    {
        public static void CourseInfo()
        {
            using (var context = new SchoolContext())
            {
                var courses = context.Courses.Select(c => new {c.Name }).ToList();
                foreach (var course in courses)
                {
                    Console.WriteLine( "Name: " + course.Name);
                }
            }
        }

    }
}
