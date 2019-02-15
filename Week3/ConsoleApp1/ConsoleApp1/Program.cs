using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void print(DirectoryInfo d, int cursor) // создаем функцию , даем ему файлы и курсор
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            FileSystemInfo[] fsis = d.GetFileSystemInfos(); // создаем массив и присваиваем ему файлы и папки
            for (int i = 0; i < fsis.Length; i++) // цикл массива
            {
                if (fsis[i].GetType() == typeof(DirectoryInfo)) // если элемент типа папки, то цвет шрифта - белый
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (fsis[i].GetType() == typeof(FileInfo)) // если элемент типа файл, то цвет шрифта - magenta
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                if (i == cursor) // цвет шрифта где стоит курсор - darkcyan
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black; // все остальное - черное
                }
                Console.WriteLine(fsis[i].Name); // выводим 
            }
        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\user\Desktop\PP2"; //даем путь к папке
            DirectoryInfo d = new DirectoryInfo(path); // открываем директорию и даем ему путь к папке
            int cursor = 0; //создаем курсор
            print(d, cursor); // вызываем функцию для директории и курсора
            int n = d.GetFileSystemInfos().Length; // количество элементов в директории
            while (true) // запускаем вечный цикл, чтобы обновлять каждый раз когда считываем клавишу
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();// читаем клавишу
                FileSystemInfo[] fsis = d.GetFileSystemInfos(); // массив элементов в директории
                if (keyInfo.Key == ConsoleKey.UpArrow) // если при нажатии стрелки вверх курсор уходит за грань, то нужно переместить его в самый низ
                {
                    cursor--;
                    if (cursor == -1)
                    {
                        cursor = n - 1;
                    }

                }
                if (keyInfo.Key == ConsoleKey.DownArrow)// если при нажатии стрелки вниз курсор уходит за грань, то нужно переместить его на первый элемент
                {
                    cursor++;
                    if (cursor == n)
                    {
                        cursor = 0;
                    }
                }
                if (keyInfo.Key == ConsoleKey.Enter) // при нажатии enter
                {
                    if (fsis[cursor].GetType() == typeof(DirectoryInfo)) // если элемент на котором стоит курсор- папка
                    {
                        d = new DirectoryInfo(fsis[cursor].FullName); // зайти в эту папку
                        n = d.GetFileSystemInfos().Length;
                        cursor = 0; // обнулить курсор
                    }
                    if (fsis[cursor].GetType() == typeof(FileInfo)) // если элемент на котором стоит курсор- файл
                    {
                        StreamReader sr = new StreamReader(fsis[cursor].FullName); //прочитать его
                        Console.Clear();
                        Console.WriteLine(sr.ReadToEnd()); // прочитать до конца
                        Console.ReadKey();
                    }
                }
                if (keyInfo.Key == ConsoleKey.Backspace) // при нажатии backspace
                {
                    if (d.Parent != null) // если у него есть родитель
                    {
                        d = d.Parent; // то d является его родителем
                        n = d.GetFileSystemInfos().Length;  // количество элементов
                        cursor = 0; // обнулить курсор
                    }
                    else // если выйти некуда, то не выполнять
                    {
                        break;
                    }
                }
                if (keyInfo.Key == ConsoleKey.D) // при нажатии "D"
                {
                    if (fsis[cursor].GetType() == typeof(DirectoryInfo)) // если элемент на котором стоит курсор- папка
                    {
                            Directory.Delete(fsis[cursor].FullName); // удалить эту папку
                    }
                    if (fsis[cursor].GetType() == typeof(FileInfo)) // если элемент на котором стоит курсор- файл
                    {
                            File.Delete(fsis[cursor].FullName); // удалить этот файл
                    }
                }
                if (keyInfo.Key == ConsoleKey.R) // при нажатии "R"
                {

                    if (fsis[cursor].GetType() == typeof(DirectoryInfo)) // если элемент на котором стоит курсор- папка
                    {
                        Console.Clear();
                        Console.WriteLine("Please type new name of folder");
                        string s = Console.ReadLine(); // написать новое название
                        string fileName = fsis[cursor].Name; // считываем имя папки
                        string dirPath = fsis[cursor].FullName; // считываем весь путь к данной папке
                        int len = fileName.Length;
                        string newpath = ""; //создаем новый путь
                        for (int i = 0; i < dirPath.Length - len; i++) //цикл до пути(не включая саму папку)
                        {
                            newpath = newpath + dirPath[i]; // новый путь то самой папки
                        }
                        newpath = newpath + s; //прибавляем к пути новое название
                        Directory.Move(dirPath, newpath); // переместить новый путь
                    }
                    if (fsis[cursor].GetType() == typeof(FileInfo)) // если элемент на котором стоит курсор- файл
                    {
                        Console.Clear(); // очистить консоль
                        string s = Console.ReadLine(); // написать новое название
                        string fileName = fsis[cursor].Name;// считываем имя файла
                        string dirPath = fsis[cursor].FullName;// считываем весь путь к данному файлу
                        int len = fileName.Length;
                        string newpath = "";//создаем новый путь
                        for (int i = 0; i < dirPath.Length - len; i++)//цикл до пути(не включая сам файл)
                        {
                            newpath = newpath + dirPath[i];// новый путь до самого файла
                        }
                        newpath = newpath + s; //прибавляем к пути новое название
                        File.Move(dirPath, newpath);
                    }
                }

                print(d, cursor);

            }
        }

    }
}
