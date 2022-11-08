using System;

namespace Practical_work_11._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"data.csv";
            Consultant cons = new Consultant(path);

            do
            {
                Console.Clear();
                Console.WriteLine("[1] - Вывести данные на экран;");
                Console.WriteLine("[2] - Редактировать запись");
                Console.WriteLine("[3] - Выход из программы");

                var n = Console.ReadKey(true).Key;

                switch (n)
                {
                    case ConsoleKey.D1: cons.PrintDbToConsole(); break;
                    case ConsoleKey.D2: cons.EditRecord(); break;
                    case ConsoleKey.D3: return;
                    default: continue;
                }
            }
            while (true);
        }
    }
}