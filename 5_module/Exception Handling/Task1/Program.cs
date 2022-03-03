using System;
using Task2;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //PrintFirstCharOfStr("Hello World");
            NumberParser parser = new NumberParser();
            parser.Parse("0-12034");
        }

        /*

         Задание 1:

        Откройте класс программы в рамках проекта Task 1 и реализуйте метод, 
        который печатает первый символ каждой введенной строки ввода. 
        Используйте механизм обработки исключений для проверки ввода пустой строки.

         */

        public static void PrintFirstCharOfStr(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (str.Length == 0)
            {
                return;
            }

            Console.WriteLine(str[0]);

            string[] strArr = new string[5] { "First", "Second", "Third", "Fourth", "Fifth"};

            foreach (string item in strArr)
            {
                Console.WriteLine(item[0]);
            }
        }
    }
}