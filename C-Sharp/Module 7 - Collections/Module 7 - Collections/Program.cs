using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_7___Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateStudentArrayList();

            // The teacher
            Teacher[] teacherArray = new Teacher[3];
            teacherArray[0] = new Teacher("Gerry", "O'Brien", "Redmond", "WA", "Information Technology", 1);

            // The course
            var course = new Course(teacherArray);
            course.name = "Programming with C#";

            // The degree
            var degree = new Degree(course);
            degree.name = "Bachelor of Science";

            // The program
            var uprogram = new UProgram();
            uprogram.name = "Information Technology";
            uprogram.course = course;
            uprogram.degree = degree;

            PrintEverything(uprogram, degree, course);
        }

        static void CreateStudentArrayList()
        {
            ArrayList students = new ArrayList();
            // The student objects
            Student student0 = new Student("Michael", "Winston", "Manhattan", "NY");
            Student student1 = new Student("Jalal", "Abramsson", "Queens", "NY");
            Student student2 = new Student("Arnleik", "Gjersvik", "Brooklyn", "NY");
            // Add them to the collection
            students.Add(student0);
            students.Add(student1);
            students.Add(student2);

            Course.ListStudents(students);
        }
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
        public string classPassed { get; set; }
        public Stack Grades { get; set; }

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
        public Object course { get; set; }
        public Object degree { get; set; }
    }
    class Course : UProgram
    {
        // member variables
        public Teacher[] teacherArray { get; set; }
        private static Random r = new Random();
        public Course(Teacher[] _teacherArray)
        {
            this.teacherArray = _teacherArray;
        }
        public static void ListStudents(ArrayList students)
        {
            foreach (Student student in students)
            {
                // Retrieve them from the collection and cast them back to Student objects
                Student _student = (Student)student;
                // Grades
                Stack Grades = new Stack();
                // Random number generator
                Grades.Push(r.Next(50, 100));
                Grades.Push(r.Next(50, 100));
                Grades.Push(r.Next(50, 100));
                Grades.Push(r.Next(50, 100));
                Grades.Push(r.Next(50, 100));

                Console.WriteLine("{0} {1}", student.firstName, student.lastName);
                Console.Write("Grades: ");
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
        // member variables
        public Course courseObject { get; set; }
        public Degree(Course _courseObject)
        {
            this.courseObject = _courseObject;
        }
    }
    #endregion
}
