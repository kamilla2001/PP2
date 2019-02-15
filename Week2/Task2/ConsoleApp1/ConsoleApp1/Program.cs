using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = File.ReadAllText(@"C:\Users\user\Desktop\PP2_sample\1.txt");

            int c = 0;
            string[] nums = s.Split(new char[] { ',', ';', '#', ' ' }); //read numbers from input to array of string
            for (int i = 0; i < nums.Length; i++) //trying to find how many numbers are there
            {
                if (nums[i] != " ")
                {
                    c++;
                }
            }
            int n = c;
            int[] mas = new int[n]; // create array mas
            int[] mas2 = new int[n]; // create array mas2   
            for (int i = 0; i < n; i++)
            {
                mas[i] = int.Parse(nums[i]); // convert from string to our array of integers
            }

            int cnt = 0; // counter
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j <= mas[i]; j++)
                {
                    if (mas[i] % j == 0)
                    {
                        cnt++;
                    }
                }
                if (cnt == 2)
                {
                    mas2[i] = mas[i];
                }
                else
                    mas2[i] = 0;
                cnt = 0;
            }

            StreamWriter F1 = new StreamWriter(@"C:\Users\user\Desktop\PP2_sample\2.txt");
            for (int i = 0; i < n; i++)
            {
                if (mas2[i] != 0)
                {
                    F1.Write(mas2[i] + " ");
                }

            }
            F1.Close();
            Console.ReadKey();
        }
    }
}
