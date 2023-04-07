using Microsoft.Data.SqlClient;
using System.Data;

namespace Individuellt_databasprojekt
{
    internal class GradeService
    {
        public static void AddGrade()
        {
            using (var connection = new SqlConnection(@"Server=DESKTOP-EPSSJ94\MSSQLSERVER01;Database=Highschool;Trusted_Connection=True;"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SqlCommand("AddGrade", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Transaction = transaction;

                            Console.WriteLine("Enter the ID of the student:");
                            var studentId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the date the grade was set (dd/mm/yyyy):");
                            var gradeDate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter your Teacher ID:");
                            var enteredBy = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the ID of the course:");
                            var courseId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the grade (1-5):");
                            var grade = int.Parse(Console.ReadLine());

                            command.Parameters.AddWithValue("@studentId", studentId);
                            command.Parameters.AddWithValue("@gradeDate", gradeDate);
                            command.Parameters.AddWithValue("@enteredBy", enteredBy);
                            command.Parameters.AddWithValue("@courseId", courseId);
                            command.Parameters.AddWithValue("@grade", grade);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        Console.WriteLine("You have successfully added a grade to a student with a transaction");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction failed: " + ex.Message);
                    }
                }
            }
        }
        public static void ViewGrades()
        {
            Console.WriteLine("Do you want to view grades? (Enter 1 for Yes, any other key for No)");
            var userInput = Console.ReadLine();
            if (userInput != "1") return;

            using (var connection = new SqlConnection(@"Server=DESKTOP-EPSSJ94\MSSQLSERVER01;Database=Highschool;Trusted_Connection=True;"))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT StudentID, CourseID, TeacherID, Grade, Date FROM Grades", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("StudentID: " + reader["StudentID"] +
                                              " CourseID: " + reader["CourseID"] +
                                              " TeacherID: " + reader["TeacherID"] +
                                              " Grade: " + reader["Grade"] +
                                              " Date: " + reader["Date"]);
                        }
                    }
                }


            }
        }
    }
}

