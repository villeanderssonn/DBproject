using Individuellt_databasprojekt;



namespace Labb_3_db
{
    internal class Program
    {
        static void Main()
        {
            
            while (true)
            {
                Console.WriteLine("1. Personal overview / Add staff");
                Console.WriteLine("2. Student overview / Add student");
                Console.WriteLine("3. How many teachers work in each department?");
                Console.WriteLine("4. Display information about all students");
                Console.WriteLine("5. Display a list of all (active) courses");
                Console.WriteLine("6. How much does each department pay in salaries each month?");
                Console.WriteLine("7. What is the average salary for each department?");
                Console.WriteLine("8. Grade a student");
                Console.WriteLine("9. View students' grades and which teacher gave them.");
                Console.WriteLine("10. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        PersonnelService.PersonnelInfo();
                        break;
                    case 2:
                        Console.Clear();
                        StudentService.StudentInfo();
                        StudentService.AddStudent();
                        break;
                    case 3:
                        Console.Clear();
                        PersonnelService.PersonnelInfo();
                        break;
                    case 4:
                        Console.Clear();
                        StudentService.StudentInfo();
                        break;
                    case 5:
                        CourseService.CourseInfo();
                        break;
                    case 6:
                        Console.Clear();
                        SalaryService.SalaryInfo();
                        break;
                    case 7:
                        Console.Clear();
                        SalaryService.PrintAverageSalary();
                        break;
                    case 8:
                        Console.Clear();
                        GradeService.AddGrade();
                        break;
                    case 9:
                        Console.Clear();
                        GradeService.ViewGrades();
                        break;
                    case 10:
                        return;
                }
            }
        }

    }
}