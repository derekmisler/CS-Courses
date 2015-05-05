using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information___Week_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize variables
            string first = "";
            string last = "";
            string birthday = "";
            string course = "";
            string program = "";
            string teacher = "";
            string degree = "";

            // call Get method
            GetStudentInfo(out first, out last, out birthday, out course, out program, out teacher, out degree);

            // validate the birthday
            try
            {
                ValidateBirthday();
            }
            catch (NotImplementedException notImp)
            {
                Console.WriteLine("Invalid birthday! Try again.");
                Console.WriteLine(notImp.Message);
            }

            // call Print method
            PrintStudentDetails(first, last, birthday, course, program, teacher, degree);

            // wait for user to hit "enter" to close the window
            Console.Write("Press any key to exit...");
            Console.ReadLine();
        }
        // Get student, course, and teacher information
        static void GetStudentInfo(out string first, out string last, out string birthday, out string teacher, out string course, out string program, out string degree)
        {
            Console.Write("Enter the student's first name: ");
            first = Console.ReadLine();
            Console.Write("Enter the student's last name: ");
            last = Console.ReadLine();
            Console.Write("Enter the student's birthday: ");
            birthday = Console.ReadLine();
            Console.Write("Enter the teacher's name: ");
            teacher = Console.ReadLine();
            Console.Write("Enter the course initials: ");
            course = Console.ReadLine();
            Console.Write("Enter the program description: ");
            program = Console.ReadLine();
            Console.Write("Enter the degree type: ");
            degree = Console.ReadLine();
            return;
        }
        // Print the information to the console
        static void PrintStudentDetails(string first, string last, string birthday, string teacher, string course, string program, string degree)
        {
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("Hello, {0} {1}!", first, last);
            Console.WriteLine("Your birthday is {0}", birthday);
            Console.WriteLine("You are currently studying {0} {1}.", course, program);
            Console.WriteLine("{0} is taught by {1}.", course, teacher);
            Console.WriteLine("You are attaining a {0} degree.", degree);
            Console.WriteLine("_________________________________________________");
        }
        // Birthday validation method (the challenge is not being submitted, so this does not need to be completed)
        static void ValidateBirthday()
        {
        }
    }
}
