using Module_5___Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_5___Classes
{
    class Program
    {
        static void Main(string[] args)
        {            
            // The students
            Student[] studentArray = new Student[3];
            studentArray[0] = new Student("Michael", "Winston", "Manhattan", "NY");
            studentArray[1] = new Student("Jalal", "Abramsson", "Queens", "NY");
            studentArray[2] = new Student("Arnleik", "Gjersvik", "Brooklyn", "NY");

            // The teacher
            Teacher[] teacherArray = new Teacher[3];
            teacherArray[0] = new Teacher("Gerry", "O'Brien");

            // The course
            var course = new Course("Programming with C#", studentArray, teacherArray);

            // The degree
            var degree = new Degree("Bachelor of Science", course);

            // The program
            var uprogram = new UProgram("Information Technology", degree, course);

            // Print everything
            Console.WriteLine("The {0} program contains the {1} degree\n", uprogram.programName, degree.degreeName);
            Console.WriteLine("The {0} degree contains the course {1}\n", degree.degreeName, course.courseName);
            Console.WriteLine("The {0} course contains {1} student(s)", course.courseName, Student.numOfStudents.ToString());
            Console.Write("Press any key to continue . . .");
            Console.ReadLine();
        }

    }

    class Student
    {
        // Declare member variables
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string cityName { get; set; }
        public string stateName { get; set; }
        public static int numOfStudents = 0;

        // Constructor
        public Student(string _firstName, string _lastName, string _cityName, string _stateName)
        {
            numOfStudents++;
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.cityName = _cityName;
            this.stateName = _stateName;
        }
    }
    class Teacher
    {
        // Declare member variables
        public string teacherFirstName { get; set; }
        public string teacherLastName { get; set; }

        // Constructor
        public Teacher(string _teacherFirstName, string _teacherLastName)
        {
            this.teacherFirstName = _teacherFirstName;
            this.teacherLastName = _teacherLastName;
        }
    }
    class Course
    {
        // Declare member variables
        public Student[] studentArray { get; set; }
        public Teacher[] teacherArray { get; set; }
        public string courseName { get; set; }
        public Course(string _courseName, Student[] _studentArray, Teacher[] _teacherArray)
        {
            this.courseName = _courseName;
            this.teacherArray = _teacherArray;
            this.studentArray = _studentArray;
        }
    }
    class Degree
    {
        // Declare member variables
        public string degreeName { get; set; }
        public Course courseObject {get; set; }
        public Degree(string _degreeName, Course _courseObject)
        {
            this.degreeName = _degreeName;
            this.courseObject = _courseObject;
        }
    }
    class UProgram
    {
        // Declare member variables
        public string programName {get; set; }
        public Degree degreeObject { get; set; }
        public Course courseObject { get; set; }
        public UProgram(string _programName, Degree _degreeObject, Course _courseObject)
        {
            this.programName = _programName;
            this.degreeObject = _degreeObject;
            this.courseObject = _courseObject;
        }
    }
}