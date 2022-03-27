using System;
using System.IO;
using Task2;
using Task3.Tests;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string str = "First Message";
            while (str != "stop")
            {
                PrintFirstCharOfStr(str);
                str = Console.ReadLine();
            }
        }

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
        }

    }
}