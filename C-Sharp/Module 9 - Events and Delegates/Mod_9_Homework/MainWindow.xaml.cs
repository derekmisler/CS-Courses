using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mod_9_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> students { get; set; }
        public static int i = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            this.students = new List<Student>();
        }

        public void btnCreateStudent_Click(object sender, RoutedEventArgs e)
        {
            // The student object
            Student student = new Student();
            // Add to collection
            students.Add(student);
            // Add info
            students[i].firstName = txtFirstName.Text;
            students[i].lastName = txtLastName.Text;
            students[i].city = txtCity.Text;
            // Uncomment this line if you enjoy watching the console
            //Console.WriteLine("Added students[{0}]\n{1} {2} from {3}", i, students[i].firstName, students[i].lastName, students[i].city);

            // empty the form
            txtFirstName.Clear();
            txtLastName.Clear();
            txtCity.Clear();
            i++;
        }

        public void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (i >= Student.numOfStudents - 1)
            {
                i = 0;
            }
            else
            {
                i++;
            }
            txtFirstName.Text = students[i].firstName;
            txtLastName.Text = students[i].lastName;
            txtCity.Text = students[i].city;
        }

        public void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (i <= 0)
            {
                i = Student.numOfStudents - 1;
            }
            else
            {
                i--;
            }
            txtFirstName.Text = students[i].firstName;
            txtLastName.Text = students[i].lastName;
            txtCity.Text = students[i].city;
        }
    }
    public class Student
    {
        // member variables
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string city { get; set; }

        // This is to make sure the arrows don't go out of bounds
        public static int numOfStudents = 0;
        public Student()
        {
            numOfStudents++;
        }
    }
}
