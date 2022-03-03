using System;
using ClassLibrary;



namespace CoreApp
{
    class Program
    {
        static void Main(String[] args)
        {
          //  Console.WriteLine("Hello, " + String.Join(" ", args) + "!");

            Console.WriteLine("Enter Username");
            string username = Console.ReadLine();
            // task 1
            // Console.WriteLine("Hello, " + username + "!");

            // task 2
            StringOperation operation = new StringOperation();
            Console.WriteLine(operation.DisplayInfo(username));
        }
    }
}
