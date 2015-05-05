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
            for (int row = 0; row < 8; row++) //loop for the 8 rows
            {
                for (int column = 0; column < 4; column++) //loop for the 4 columns, 2 squares in each column
                {
                    if (row % 2 == 0) //if even row, start with X. else, start with O
                    {
                        Console.Write("XO");
                    }
                    else
                    {
                        Console.Write("OX");
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }
    }
}
