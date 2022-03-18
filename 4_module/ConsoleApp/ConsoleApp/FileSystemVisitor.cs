using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class FileSystemVisitor
    {
        public delegate void Notify(string message);
        public event Notify ProcessStatus;

        private readonly string _root;
        private readonly Predicate<string> _filter = x => true;

        private readonly bool _flag = false;

        public FileSystemVisitor(string root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            if (!Directory.Exists(root))
            {
                throw new DirectoryNotFoundException();
            }

            _root = root;
        }

        public FileSystemVisitor(string root, Predicate<string> filter) : this(root)
        {
            if (filter == null) { throw new ArgumentNullException(nameof(filter)); }
            _filter = filter;
            _flag = true;
        }

        public IEnumerable<string> VisitFiles(string root)
        {
            ProcessStatus?.Invoke("Process Started");

            var message = _flag ? "Filtered File Found" : "File Found";
            ProcessStatus?.Invoke(message);

            int counter = 0;

            foreach (var filePath in Directory.EnumerateFiles(root))
            {
                if (_filter(filePath))
                {
                    var file = filePath.Split('\\');
                    yield return file[file.Length - 1];
                    counter++;
                }
            }

            if(counter == 0)
            {
                ProcessStatus?.Invoke("Nothing had been found");
            }

            foreach (var item in VisitDirectory(root))
            {
                yield return item;
            }
        }

        private IEnumerable<string> VisitDirectory(string root)
        {
            var message = _flag ? "Filtered Folder Found" : "Folder Found";
            ProcessStatus?.Invoke(message);

            int counter = 0;

            foreach (var subDirectory in Directory.EnumerateDirectories(root))
            {
                var directory = subDirectory.Split('\\');
                if (_filter(directory[directory.Length - 1]))
                {
                    yield return directory[directory.Length - 1];
                    counter++;
                }
            }

            if (counter == 0)
            {
                ProcessStatus?.Invoke("Nothing had been found");
            }
            ProcessStatus?.Invoke("Process Finished");
        }

        #region IfYouWantToGetAllFilesFromFolders
        public IEnumerable<string> GetAllFIles(string root)
        {
            foreach (var subDirectory in Directory.EnumerateDirectories(root))
            {
                foreach (var item in VisitFiles(subDirectory))
                {
                    if (_filter(item))
                    {
                        yield return item;
                    }
                }
            }
        }
        #endregion
    }


}
