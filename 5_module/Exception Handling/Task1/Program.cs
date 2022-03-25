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
            //PrintFirstCharOfStr("Hello World");
            /*  string str="First Message";
              while (str!="stop")
              {                
                  PrintFirstCharOfStr(str);
                  str = Console.ReadLine();
              }*/

            JustForCheck();
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

        public static void JustForCheck()
        {
            object obj = "STRING OBJECT";
            string str = "STRING";
            int number = 123;

            try
            {
                Console.WriteLine("str[100]:  " + str[100]);
                // number = (int)obj;
                // Console.WriteLine("number:  " + number);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error message "+ex.Message);
                Console.WriteLine("список иерархии вызовов методов \n" + ex.StackTrace);
                // throw ex;
               // throw;
              // throw new MySpecialException("Special message");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(str);
            }
           

            try
            {
                try
                {
                    throw new ArgumentException();
                }
                catch (ArgumentException e)
                {
                    //make sure this path does not exist
                    if (!File.Exists("C:\\test.pdf"))
                    {
                        throw new FileNotFoundException("File Not found when trying to write argument exception to the file", e);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Concat(e.StackTrace, e.Message));

                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner Exception");
                    Console.WriteLine(String.Concat(e.InnerException.StackTrace, e.InnerException.Message));
                }
            }
            Console.ReadLine();

        }
    }

    [Serializable]
    public class MySpecialException : Exception
    {
        public MySpecialException() { }

        public MySpecialException(string message)
            : base(message) { }

        public MySpecialException(string message, Exception inner)
            : base(message, inner) { }

    }
}