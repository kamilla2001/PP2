using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // вводим количество элементов и конвертируем в интеджер

            Method(n);//вызываем метод для данного числа

        }

        static void Method(int n) // метод(функция)
        {
            string[] s = Console.ReadLine().Split(' '); //считываем целую строку с числами и сразу же разделяем

            int[] arr = new int[n * 2]; // новый массив с двойным количеством

            int j = 0;
            for (int i = 0; i < s.Length; i++) //заполняем новый массив двойными элементами
            {
                arr[i + j] = int.Parse(s[i]);
                arr[i + j + 1] = int.Parse(s[i]);
                j++;
            }

            foreach (int i in arr) // для каждого элемента в массиве
            {
                Console.Write($"{i} "); // вывод его элемента
            }

        }
    }
}