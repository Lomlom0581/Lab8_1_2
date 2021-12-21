using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
        begin:
            Console.Write("Введите номер задачи (1-2):");

            string Selected = Console.ReadLine();

            switch (Selected)
            {
                case "1":
                    Exercice1();
                    break;
                case "2":
                    Exercice2();
                    break;

                default:
                    Console.WriteLine("Введен неверный номер упражнения, попрбуйте еще раз.");
                    goto begin;
            }

        }

        static void Exercice1()
        {
            Console.WriteLine(@"Выберите любую папку на своем компьютере, имеющую вложенные директории.
Выведите на консоль ее содержимое и содержимое всех подкаталогов.");
            Console.WriteLine("");

            var AllFolders = System.IO.Directory.GetDirectories("c:\\");

            Random r = new Random();

        start:

            var RandomFolderNumber = r.Next(AllFolders.Length);

            var SelectedFolder = AllFolders[RandomFolderNumber];


            if (SelectedFolder == "c:\\Documents and Settings"
                || SelectedFolder == "c:\\Windows"
                || SelectedFolder == "c:\\System Volume Information"
                || SelectedFolder == "c:\\$RECYCLE.BIN")
                goto start;


            Console.WriteLine($"Случайным образом выбрана папка {SelectedFolder}");

            var Allfiles = System.IO.Directory.EnumerateFiles(SelectedFolder, "*.*", System.IO.SearchOption.AllDirectories);

            foreach (string file in Allfiles)
                Console.WriteLine(file);

            Console.ReadKey();
        }

        static void Exercice2()
        {
            Console.WriteLine(@"Программно создайте текстовый файл и запишите в него 10 случайных чисел.
Затем программно откройте созданный файл, рассчитайте сумму чисел в нем, ответ выведите на консоль.");
            Console.WriteLine("");

            Random r = new Random();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 10; i++)
                sb.Append(r.Next(0, 100) + " ");

            string UserFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            string FilePath = System.IO.Path.Combine(UserFolder, "Desktop", "RandomNumbers.txt");
            Console.WriteLine("Пытаемся записать в файл:" + FilePath);

            System.IO.File.WriteAllText(FilePath, sb.ToString());

            Console.WriteLine("Файл записан");

            string ReadedText = System.IO.File.ReadAllText(FilePath);

            Console.WriteLine($"Считали текст: {ReadedText}");

            int Sum = 0;

            foreach (string number in ReadedText.Split(' '))
            {
                if (number == "") continue;
                Sum += Convert.ToInt32(number);
            }

            Console.WriteLine($"Сумма : {Sum}");


            Console.ReadKey();
        }
    }
}
