using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter New = new StreamWriter(@"C:\Users\user\Desktop\PP2_sample\4.txt");
            New.Write(3333);
            New.Close();

            File.Copy(@"C:\Users\user\Desktop\PP2_sample\4.txt", @"C:\Users\user\Desktop\PP2_sample\5.txt");
            File.Delete(@"C:\Users\user\Desktop\PP2_sample\4.txt");
        }
    }
}
