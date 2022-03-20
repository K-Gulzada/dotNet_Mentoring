using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class FakeFileSystemVisitor
    {
        private IFileSystem _fileSystem;
        public delegate void Notify(string message);
        public event Notify ProcessStatus;

        private readonly string _root;
        private readonly Predicate<string> _filter = x => true;

        private readonly bool _flag = false;
        public FakeFileSystemVisitor(IFileSystem fileSystem, string root)
        {
            _fileSystem = fileSystem;

            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
        
            if (!_fileSystem.Directory.Exists(root))
            {
                throw new DirectoryNotFoundException();
            }
            _root = root;
        }

        public FakeFileSystemVisitor(IFileSystem fileSystem, string root, Predicate<string> filter) : this(fileSystem, root)
        {
            if (filter == null) { throw new ArgumentNullException(nameof(filter)); }
            _filter = filter;
            _flag = true;
        }

        public virtual IEnumerable<string> VisitFiles(string root)
        {
            ProcessStatus?.Invoke("Process Started");

            ProcessStatus?.Invoke(GetStatusMessage("file"));

            int counter = 0;

            foreach (var filePath in _fileSystem.Directory.EnumerateFiles(root))
            {
                if (_filter(filePath))
                {
                    var file = filePath.Split('\\');
                    yield return file[file.Length - 1];
                    counter++;
                }
            }

            if (counter == 0)
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
            ProcessStatus?.Invoke(GetStatusMessage("folder"));

            int counter = 0;

            foreach (var subDirectory in _fileSystem.Directory.EnumerateDirectories(root))
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

        private string GetStatusMessage(string type)
        {
            string message = String.Empty;

            if (type.ToLower() == "file")
            {
                message = _flag ? "Filtered File Found" : "File Found";
            }
            if (type.ToLower() == "folder")
            {
                message = _flag ? "Filtered Folder Found" : "Folder Found";
            }

            return message;
        }


    }
}
