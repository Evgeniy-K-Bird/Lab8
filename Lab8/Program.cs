using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Autodesk";
            if (Directory.Exists(path)) // Если путь существет то:
            { 
                string[] folder = Directory.GetDirectories(path); // Список путей (folder) каталогов в массив, по указаному пути вначале (path)
                DirectoryInfo infoFolder = new DirectoryInfo(path); // Создаем Х (Что это? некое имя infoFolder, которое содержит много данных о папке в этом пути. массив?)
                Console.WriteLine("Содержание папки \"{0}\":",infoFolder.Name); // теперь из этого Х можно вытаскивать чтото, и мы тащим Name. масив из которого информация вытаскивается по мени, а не по индексу?
                #region Что делаем с папками
                foreach (string s in folder) // s - это переменное значение (путь), всех папок 
                {
                    DirectoryInfo infoFolder2 = new DirectoryInfo(s); // создаем X2 infoFolder2 для каждого пути
                    Console.WriteLine("\t[.] {0}", infoFolder2.Name); // тащим их имена из каждого Х
                    string[] folder2 = Directory.GetDirectories(s); // создаем пути вложенных папок 
                    string[] files2 = Directory.GetFiles(s); // создаем пути файлов вложенных папок 
                    foreach (string s2 in folder2) // обработка путей вложенных папок s2
                    {
                        DirectoryInfo infoFolder3 = new DirectoryInfo(s2);
                        Console.WriteLine("\t\t[..] {0}", infoFolder3.Name);
                    }
                    foreach (string s3 in files2)
                    {
                        FileInfo infoFile2 = new FileInfo(s3);
                        Console.WriteLine("\t\t{0}", infoFile2.Name);
                    }
                }
                #endregion
                #region Что делаем с файлами
                string[] files = Directory.GetFiles(path);
                foreach (string s in files)
                {
                    FileInfo infoFile = new FileInfo(s);
                    Console.WriteLine("\t{0}", infoFile.Name);
                }
                #endregion
                Console.ReadKey();
            }
            else // Если путь не существет то:
            {
                Console.WriteLine("Папка по данному пути отсутствует");
            }
        }
    }
}