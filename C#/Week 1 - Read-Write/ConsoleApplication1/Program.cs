using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Derek";
            string lastName = "Misler";
            string birthDate = "1/1/70";
            string address1 = "123 Main Street";
            string address2 = "Apt. 4";
            string city = "New York";
            string state = "NY";
            int zip = 10001;
            string country = "USA";
            string gender = "male";

            string professorName = "Professor Microsoft";
            string professorEducation = "Ph.D Microsoft University";
            string professorArea = "Accounting and Law";

            string degreeName = "Master of Computer Science";
            int creditsRequired = 100;

            string courseName = "Programming with C#";
            string courseNumber = "DEV204";
            string degreeOffered = "Certificate";
            int courseCredits = 15;
            string courseDescription = "This is an intermediate-level course on programming with C#.";


            Console.WriteLine("Student Information");
            Console.WriteLine("Your name is: {0} {1}", firstName, lastName);
            Console.WriteLine("Your birthdate is: {0}", birthDate);
            Console.WriteLine("Your address is: {0}, {1}, {2} {3}, {4}, {5}", address1, address2, city, state, zip, country);
            Console.WriteLine("Your gender is: {0}", gender);
            Console.WriteLine("___________________________________");
            Console.WriteLine("Professor Information");
            Console.WriteLine("The professor is: {0}", professorName);
            Console.WriteLine("Education: {0}", professorEducation);
            Console.WriteLine("Area of expertise: {0}", professorArea);
            Console.WriteLine("___________________________________");
            Console.WriteLine("Degree Information");
            Console.WriteLine("Name: {0}", degreeName);
            Console.WriteLine("Credits Required: {0}", creditsRequired);
            Console.WriteLine("___________________________________");
            Console.WriteLine("Program Information");
            Console.WriteLine("Course: {0} {1}", courseNumber, courseName);
            Console.WriteLine("Available degree: {0}", degreeOffered);
            Console.WriteLine("Course credits: {0}", courseCredits);
            Console.WriteLine("Department head: {0}", professorName);
            Console.WriteLine("Course description: {0}", courseDescription);

            Console.Read();
        }
    }
}
