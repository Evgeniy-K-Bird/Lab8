using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace z2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "file.txt";
            if (!File.Exists(path))
            {
                FileStream fs = File.Create(path);
                fs.Close();
                Console.WriteLine("Файл отсутствовал и был создан!");
            }
            Console.WriteLine("Файл уже есть, производим запись данных...");
            StreamWriter f1 = new StreamWriter(path);
            Random r = new Random();
            for (int i = 0; i < 10; i++) f1.WriteLine(r.Next(0, 100));
            f1.Close();
            Console.WriteLine("Данные в файл записаны, для продолжения нажмите Enter");
            Console.ReadLine();
            StreamReader fr = new StreamReader(path);
            string s = fr.ReadToEnd();
            string[] strNumbers = System.IO.File.ReadAllLines(path);
            int count = 0;
            foreach (string strNumber in strNumbers)
            {
                if (Int32.TryParse(strNumber, out int number))
                {
                    count = count + number;
                }
            }
            Console.WriteLine("Сумма всех чисел в файле: " + count);
            fr.Close();
            Console.ReadLine();

        }
    }
}
