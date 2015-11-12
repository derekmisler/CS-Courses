using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_8___Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            // Teachers
            var teachers = new List<Teacher>();
            Course.CreateTeacherList(teachers);

            // Students
            var students = new List<Student>();
            Course.CreateStudentList(students);

            // Print Students and their grades
            Course.ListStudents(students);

            // The course
            var course = new Course();
            course.name = "Programming with C#";

            // The degree
            var degree = new Degree();
            degree.name = "Bachelor of Science";
            degree.course = course;

            // The program
            var uprogram = new UProgram();
            uprogram.name = "Information Technology";
            uprogram.course = course;
            uprogram.degree = degree;

            // Print program, degree, and course information
            PrintEverything(uprogram, degree, course);
        }

        // Method for printing
        static void PrintEverything(UProgram uprogram, Degree degree, Course course)
        {
            Console.WriteLine("The {0} program contains the {1} degree\n", uprogram.name, degree.name);
            Console.WriteLine("The {0} degree contains the course {1}\n", degree.name, course.name);
            Console.WriteLine("The {0} course contains {1} student(s)", course.name, Student.numOfStudents.ToString());

            Console.Write("Press any key to continue . . .");
            Console.ReadLine();
        }
    }
    #region Classes
    class Person
    {
        // member variables to share with Student and Teacher classes
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }
    class Student : Person
    {
        // member variables
        public static int numOfStudents = 0;
        public static Stack<int> Grades = new Stack<int>();

        // I need this random variable for grades
        private static Random r = new Random();

        // add five grades to the Grades stack<>
        public static void StudentGrades(Stack<int> Grades)
        {
            for (int i = 0; i < 5; i++)
            {
                Grades.Push(r.Next(50, 100));
            }
        }

        // Build the student profile
        public Student(string _firstName, string _lastName, string _city, string _state)
        {
            numOfStudents++;
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.city = _city;
            this.state = _state;
        }
    }
    class Teacher : Person
    {
        // member variables
        public int empNumber { get; set; }
        public string department { get; set; }
        // Teacher profile
        public Teacher(string _firstName, string _lastName, string _city, string _state, string _department, int _empNumber)
        {
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.city = _city;
            this.state = _state;
            this.department = _department;
            this.empNumber = _empNumber;
        }
    }
    class UProgram
    {
        // member variables
        public string name { get; set; }
        public Course course { get; set; }
        public Degree degree { get; set; }
    }
    class Course : UProgram
    {
        public static void CreateStudentList(List<Student> students)
        {
            // The student objects
            Student student0 = new Student("Michael", "Winston", "Manhattan", "NY");
            Student student1 = new Student("Jalal", "Abramsson", "Queens", "NY");
            Student student2 = new Student("Arnleik", "Gjersvik", "Brooklyn", "NY");
            // Add them to the list<>
            students.Add(student0);
            students.Add(student1);
            students.Add(student2);
        }
        public static void CreateTeacherList(List<Teacher> teachers)
        {
            // The teacher
            Teacher teacher1 = new Teacher("Gerry", "O'Brien", "Redmond", "WA", "Information Technology", 1);
            // Add them to the list<>
            teachers.Add(teacher1);
        }
        // method for printing students and grades
        public static void ListStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                // Print the students
                Console.WriteLine("{0} {1}", student.firstName, student.lastName);
                // Print their grades
                Console.Write("Grades: ");
                // I'm using the StudentGrades method from the Student class
                var Grades = new Stack<int>();
                Student.StudentGrades(Grades);
                foreach (int _grades in Grades)
                {
                    Console.Write("{0} ", _grades);
                }

                Console.WriteLine("\n-----------------\n");
            }
        }
    }
    class Degree : UProgram
    {
        // I'm only using 'name' inherited from UProgram, so I don't need anything here
    }
    #endregion
}
