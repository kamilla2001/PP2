using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // inputing n and converting it into int

            for (int i = 0; i < n; i++) // creating 2d array
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("[*]"); // filling points with such conditions with "[*]"
                }
                Console.WriteLine();
            }
        }
    }
}
