using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //  читаем количество элементов

            int[] a = new int[n]; // создание массива a
            int[] b = new int[n]; // создание массива b   

            string[] nums = Console.ReadLine().Split(new char[] { ',', ';', '#', ' ' }); //читаем целую строку с числами и разделяем

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(nums[i]); // конвертация элементов строки в числа
            }

            int c = 0; // заводим счетчик
            for (int i = 0; i < n; i++) // цикл массива
            {
                for (int j = 1; j <= a[i]; j++) //цикл для проверки 
                {
                    if (a[i] % j == 0) // способ проверки на простое или нет
                    {
                        c++; // количество делителей элемента массива   
                    }
                }
                if (c == 2) // если 2
                {
                    b[i] = a[i]; //то перекидываем на новый массив
                }
                else // делителей много
                    b[i] = 0; // элемент второго массива приравнимваем нулю
                c = 0; // обнуляем счетчик
            }

            for (int i = 0; i < n; i++) // цикл нового массива
            {
                if (b[i] != 0) // если не 0
                    c++; // то считаем количество элементов нового массива
            }

            Console.WriteLine(c); // вывод размера второго массива
            for (int i = 0; i < n; i++)
            {
                if (b[i] != 0) // если не 0
                    Console.Write($"{b[i]} "); // то выводим элемент
            }

            Console.ReadKey();
        }
    }
}
