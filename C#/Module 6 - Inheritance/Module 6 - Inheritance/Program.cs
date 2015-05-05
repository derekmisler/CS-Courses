using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_6___Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            // The students
            Student[] studentArray = new Student[3];

            studentArray[0] = new Student();
            studentArray[0].firstName = "Michael";
            studentArray[0].lastName = "Winston";
            studentArray[0].city = "Manhattan";
            studentArray[0].state = "NY";

            studentArray[1] = new Student();
            studentArray[1].firstName = "Jalal";
            studentArray[1].lastName = "Abramsson";
            studentArray[1].city = "Queens";
            studentArray[1].state = "NY";

            studentArray[2] = new Student();
            studentArray[2].firstName = "Arnleik";
            studentArray[2].lastName = "Gjersvik";
            studentArray[2].city = "Brooklyn";
            studentArray[2].state = "NY";

            // The teacher
            Teacher[] teacherArray = new Teacher[3];

            teacherArray[0] = new Teacher();
            teacherArray[0].firstName = "Gerry";
            teacherArray[0].lastName = "O'Brien";
            teacherArray[0].city = "Redmond";
            teacherArray[0].state = "WA";
            teacherArray[0].empNumber = 1;
            teacherArray[0].department = "Information Technology";

            // The course
            var course = new Course(studentArray, teacherArray);
            course.name = "Programming with C#";

            // The degree
            var degree = new Degree(course);
            degree.name = "Bachelor of Science";

            // The program
            var uprogram = new UProgram();
            uprogram.name = "Information Technology";
            uprogram.course = course;
            uprogram.degree = degree;

            // Take a test
            Student.TakeTest(50, 90);
            studentArray[0].classGrade = Student.testScore;
            Teacher.GradeTest(studentArray[0].classGrade);
            studentArray[0].classPassed = Teacher.testGrade;

            Student.TakeTest(80, 100);
            studentArray[1].classGrade = Student.testScore;
            Teacher.GradeTest(studentArray[1].classGrade); 
            studentArray[1].classPassed = Teacher.testGrade;

            Student.TakeTest(20, 60);
            studentArray[2].classGrade = Student.testScore;
            Teacher.GradeTest(studentArray[2].classGrade); 
            studentArray[2].classPassed = Teacher.testGrade;

            // Print everything
            Console.WriteLine("The {0} program contains the {1} degree\n", uprogram.name, degree.name);
            Console.WriteLine("The {0} degree contains the course {1}\n", degree.name, course.name);
            Console.WriteLine("The {0} course contains {1} student(s)", course.name, Student.numOfStudents.ToString());
            
            // Uncomment this if you want to see the test grades
            //Console.WriteLine("\n-----------------\nGrades:");
            //for (int i = 0; i < studentArray.Length; i++)
            //{
            //    Console.WriteLine("\n{0} = {1}\n{2}\n", studentArray[i].firstName, studentArray[i].classGrade, studentArray[i].classPassed);
            //}

            Console.Write("Press any key to continue . . .");
            Console.ReadLine();
        }
    }
    class Person
    {
        // member variables
        private string _firstName;
        private string _lastName;
        private string _city;
        private string _state;

        // properties to be shared with Student and Teacher classes
        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string city
        {
            get { return _city; }
            set { _city = value; }
        }
        public string state
        {
            get { return _state; }
            set { _state = value; }
        }
    }
    class Student : Person
    {
        // Declare member variables
        public static int numOfStudents = 0;
        public string classPassed { get; set; }
        public int classGrade { get; set; }
        public static int testScore;

        // Test method
        public static void TakeTest(int testLow, int testHigh)
        {
            // Random number generator for testScore
            Random random = new Random();
            testScore = random.Next(testLow, testHigh);
            return;
        }
        // Count 'em
        public Student()
        {
            numOfStudents++;
        }
    }
    class Teacher : Person
    {
        // member variables
        public int empNumber { get; set; }
        public string department { get; set; }
        public static string testGrade;

        // public method
        public static void GradeTest(int testScore)
        {
            if (testScore > 60)
                testGrade = "Congratulations, you've passed!";
            else
                testGrade = "Sorry, you've failed.";
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
        public Student[] studentArray { get; set; }
        public Teacher[] teacherArray { get; set; }
        public Course(Student[] _studentArray, Teacher[] _teacherArray)
        {
            this.teacherArray = _teacherArray;
            this.studentArray = _studentArray;
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

}
