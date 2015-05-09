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
            Student student0 = new Student("Michael", "Winston", "Manhattan", "NY", 10, 100);
            Student student1 = new Student("Jalal", "Abramsson", "Queens", "NY", 40, 100);
            Student student2 = new Student("Arnleik", "Gjersvik", "Brooklyn", "NY", 70, 100);
            // Add them to the collection
            students.Add(student0);
            students.Add(student1);
            students.Add(student2);

            // Grades
            Stack studentGrades = new Stack();

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
        public int minGrade;
        public int maxGrade;
        public static int testScore;
        public Stack studentGrades;

        // Test method
        public static void TakeTest(int minGrade, int maxGrade)
        {
            // Random number generator for testScore
            Random random = new Random();
            Student.testScore = random.Next(minGrade, maxGrade);
            return;
        }
        // Build the student profile
        public Student(string _firstName, string _lastName, string _city, string _state, int _minGrade, int _maxGrade)
        {
            numOfStudents++;
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.city = _city;
            this.state = _state;
            this.minGrade = _minGrade;
            this.maxGrade = _maxGrade;
            studentGrades = new Stack();
        }
    }
    class Teacher : Person
    {
        // member variables
        public int empNumber { get; set; }
        public string department { get; set; }
        public static string testGrade;
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
        // public method for grading the test
        public static void GradeTest(int testScore)
        {
            if (testScore < 60)
                testGrade = "Sorry, you've failed.";
            else if (testScore > 60 & testScore < 70)
                testGrade = "You've recieved a grade of D.";
            else if (testScore > 70 & testScore < 80)
                testGrade = "You've recieved a grade of C.";
            else if (testScore > 80 & testScore < 90)
                testGrade = "You've recieved a grade of B.";
            else
                testGrade = "Congratulations on your A!";
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
        public Course(Teacher[] _teacherArray)
        {
            this.teacherArray = _teacherArray;
        }
        public static void ListStudents(ArrayList students)
        {
            foreach (Student student in students)
            {
                // Retrieve them from the collection
                Student _student = (Student)student;

                Student.TakeTest(student.minGrade, student.maxGrade);
                Teacher.GradeTest(Student.testScore);
                student.classPassed = Teacher.testGrade;

                Console.WriteLine("{0} {1} = {2}\n{3}", student.firstName, student.lastName, Student.testScore, student.classPassed);
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
