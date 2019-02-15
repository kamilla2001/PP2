using System;
using System.IO;

namespace ConsoleApp4
{
    class Program
    {
        static void WhiteSpace(int level) // peredaem kolichestvo probelov
        {
            for (int i = 0; i < level * 4; i++)
            {
                Console.Write(' ');
            }
        }
        static void print(string path, int level)
        {
            DirectoryInfo dInfo = new DirectoryInfo(path); //получаем информация о папках и файлах
            FileInfo[] fileInfos = dInfo.GetFiles(); //создаем массив файлов и берем все файлы с того пути
            DirectoryInfo[] directoryInfos = dInfo.GetDirectories();//создаем массив папок и берем все папки с того пути
            foreach (FileInfo f in fileInfos)//создаем цикл файлов
            {
                WhiteSpace(level);//вызываем функцию пробелов
                Console.WriteLine(f.Name);//выводим сам файл
            }
            foreach (DirectoryInfo d in directoryInfos)//создаем цикл файлов
            {
                WhiteSpace(level);//вызываем функцию пробелов
                Console.WriteLine(d.Name);//выводим сам файл
                print(d.FullName, level + 1); // в случае обнаружения папки внутри папки выводим её с ещё большими пробелами
            }
        }
        static void Main(string[] args)
        {
            print(@"C:\Users\user\Desktop\PP2", 0);
        }
    }
}