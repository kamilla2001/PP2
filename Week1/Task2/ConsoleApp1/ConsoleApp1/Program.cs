using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        class student // создаем новый класс для студента
        {
            public string n; //заявляем общедоступную строку имени
            public string id;//заявляем общедоступную строку айдишки
            public int y;//заявляем общедоступное число года обучения

            public student(string name, int year) // конструктор с двумя параметрами
            {
                n = name;
                y = year;
            }

            public void yea() // функция инкремента для года обучения
            {
                y++; // увеличеваем год на один 
            }

            public void PrintInfo() // функция вывода
            {
                Console.WriteLine(n); // вывод имени
                Console.WriteLine(id); // вывод айдишки
                Console.WriteLine(y); // вывод года обучения
            }

        }
        static void Main(string[] args)
        {
            student a = new student("Kamma_Pulia", 1); // создаем новый класс с параметрами имени и года обучения
            a.id = "18bd110780"; // даем ему айдишку
            a.yea(); // вызываем метод инкремента
            a.PrintInfo(); // вызываем метод вывода
        }
    }
}