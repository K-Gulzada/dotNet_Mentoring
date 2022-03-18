using System;
using Task1;
using Task1.Tests;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tests tests = new Tests();
            tests.IndexOf_Products_ReturnsTwo();

            int[] numbers = new[] { 4, 2, 1, 3, -5 };

            Utilities.Sort(numbers);
        }
    }
}
