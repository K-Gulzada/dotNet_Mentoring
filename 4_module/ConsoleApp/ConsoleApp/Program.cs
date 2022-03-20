using System;
using System.IO.Abstractions.TestingHelpers;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
             var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
           // var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DoesNotExistFolder"; // Throw DirectoryNotFoundException
            // string path = null; // Throw ArgumentNullException

            Predicate<string> predicate = (info) => info.Contains("ml");
            //  Predicate<string> predicate = null; // Throw ArgumentNullException


           FileSystemVisitor visitor = new FileSystemVisitor(path, predicate);
            // FileSystemVisitor visitor = new FileSystemVisitor(path);
            visitor.ProcessStatus += DisplayMessage;

            void DisplayMessage(string message) => Console.WriteLine("==========" + message + "==========");
            var files = visitor.GetFilesAndFolders(path);

            foreach (var item in files)
            {
                Console.WriteLine(item);
            }

          /*  Console.WriteLine("\n\n\n");

            var mockFileSystem = new MockFileSystem();
            mockFileSystem.AddFile(("test.txt"), MockFileData.NullObject);
            mockFileSystem.AddFile(("config.xml"), MockFileData.NullObject);
           // var fakeVisitor = new VisitorWithFakeFileSystem(mockFileSystem, "C:\\");
            var fakeVisitor = new FakeFileSystemVisitor(mockFileSystem, "C:\\", predicate);

            fakeVisitor.ProcessStatus += DisplayMessage_2;

            void DisplayMessage_2(string message) => Console.WriteLine("-----------" + message + "-----------");
            var fakeFiles = fakeVisitor.VisitFiles("C:\\");

            foreach (var item in fakeFiles)
            {
                Console.WriteLine(item);
            }*/

        }

    }
}