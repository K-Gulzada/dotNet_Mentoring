using System;


namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "C:\\Users\\Gulzada_Kakhar\\Desktop";
            //  var path = "C:\\Users\\Gulzada_Kakhar\\Desktop\\DoesNotExistFolder"; // Throw DirectoryNotFoundException
            // string path = null; // Throw ArgumentNullException

            Predicate<string> predicate = (info) => info.Contains("xm");
            //  Predicate<string> predicate = null; // Throw ArgumentNullException


           // FileSystemVisitor visitor = new FileSystemVisitor(path, predicate);
              FileSystemVisitor visitor = new FileSystemVisitor(path);
            visitor.ProcessStatus += DisplayMessage;

            void DisplayMessage(string message) => Console.WriteLine("=========="+message+ "==========");
            var files = visitor.VisitFiles(path);

            foreach (var item in files)
            {
                Console.WriteLine(item);
            }


        }

    }
}