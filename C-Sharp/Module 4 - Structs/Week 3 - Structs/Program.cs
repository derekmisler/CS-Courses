using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_3___Structs
{
    class Program
    {
        // Student struct
        public struct Student
        {
            // These statements set the default values, which are
            // blank, because I'll be asking the user to enter one of them.
            // I'll fill out the rest with this constructor.
            public Student(string first, string last, string city, string state)
            {
                this.firstName = first;
                this.lastName = last;
                this.cityName = city;
                this.stateName = state;
            }
            public string firstName;
            public string lastName;
            public string cityName;
            public string stateName;
        }

        // Teacher struct
        public struct Teacher
        {
            public Teacher (string first, string last)
            {
                this.teacherFirstName = first;
                this.teacherLastName = last;
            }
            public string teacherFirstName;
            public string teacherLastName;
        }

        // Program struct (can't use 'Program' though because that's the name of the Class)
        public struct SchoolProgram
        {
            public SchoolProgram(string name, string description)
            {
                this.programName = name;
                this.programDescription = description;
            }
            public string programName;
            public string programDescription;
        }

        // Course struct
        public struct Course
        {
            public Course (string name, string degree)
            {
                this.courseName = name;
                this.degreeName = degree;
            }
            public string courseName;
            public string degreeName;
        }

        static void Main(string[] args)
        {
            // Get data from the user for the student struct
            Student student0 = new Student();
            Console.Write("Your first name: ");
            student0.firstName = Console.ReadLine();
            Console.Write("Your last name: ");
            student0.lastName = Console.ReadLine();
            Console.Write("Your home city: ");
            student0.cityName = Console.ReadLine();
            Console.Write("Your home state/province: ");
            student0.stateName = Console.ReadLine();

            // Here are the other students
            Student student1 = new Student("Jalal", "Abramsson", "Queens", "NY");
            Student student2 = new Student("Annibale", "Adamson", "Brooklyn", "NY");
            Student student3 = new Student("Travis", "Bayer", "Staten Island", "NY");
            Student student4 = new Student("Josiah", "Bond", "The Bronx", "NY");

            // Here is the student array
            Student[] studentArray = new Student[5];

            studentArray[0] = student0;
            studentArray[1] = student1;
            studentArray[2] = student2;
            studentArray[3] = student3;
            studentArray[4] = student4;

            // Teacher, Program, and Course information
            Teacher teacher1 = new Teacher("Gerry", "O'Brien");
            SchoolProgram class1 = new SchoolProgram("Programming with C#", "The C# programming language was created from the ground up to be an object-oriented programming language that offers ease of use, familiarity to C/C++ and Java developers, along with enhanced memory and resource management. C# is prevalent on the Microsoft platform but is also being used to develop software the runs on Linux, Android, and iOS devices as well.");
            Course course = new Course("DEV204x", "Certification");

            // Print everything
            Console.WriteLine("\n-----------------------------------------------\n");
            Console.WriteLine("Hello {0} {1} from {2}, {3}", studentArray[0].firstName, studentArray[0].lastName, studentArray[0].cityName, studentArray[0].stateName);
            Console.WriteLine("Welcome to {0} {1}", course.courseName, class1.programName);
            Console.WriteLine("This class will be taught by {0} {1}", teacher1.teacherFirstName, teacher1.teacherLastName);
            Console.WriteLine("\nAbout this course:\n{0}", class1.programDescription);
            Console.WriteLine("\nAfter completing this course, you will recieve a {0} degree.", course.degreeName);

            // Print other students
            Console.WriteLine("\n-----------------------------------------------\n");
            Console.WriteLine("Meet your classmates:");
            for (int i = 1; i < studentArray.GetLength(0); i++)
            {
                Console.WriteLine("{0} {1} from {2}, {3}", studentArray[i].firstName, studentArray[i].lastName, studentArray[i].cityName, studentArray[i].stateName);
            }

            // Wait for the user to close the console window
            Console.Write("\n-----------------------------------------------\nPress <ENTER> to close the window...");
            Console.ReadLine();
        }
    }
}
