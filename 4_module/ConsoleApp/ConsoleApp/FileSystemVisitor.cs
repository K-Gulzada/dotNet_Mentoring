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

        public virtual IEnumerable<string> GetFilesAndFolders(string root)
        {
            ProcessStatus?.Invoke("Process Started");
            foreach (var item in VisitFiles(root))
            {
                yield return item;
            }

            foreach (var item in VisitDirectory(root))
            {
                yield return item;
            }
            ProcessStatus?.Invoke("Process Finished");
        }
                
        private List<string> VisitFiles(string root)
        {
            int counter = 0;
            var fileList = new List<string>();

            foreach (var filePath in Directory.EnumerateFiles(root))
            {
                if (_filter(filePath))
                {
                    var file = filePath.Split('\\');
                    fileList.Add(file[file.Length - 1]);
                    counter++;

                    // SimulateSearchAbort();
                }
            }

            ProcessStatus?.Invoke(GetStatusMessage("file", counter));
            return fileList;
        }

        private List<string> VisitDirectory(string root)
        {
            int counter = 0;
            var dirList = new List<string>();

            foreach (var subDirectory in Directory.EnumerateDirectories(root))
            {
                var directory = subDirectory.Split('\\');
                if (_filter(directory[directory.Length - 1]))
                {
                    dirList.Add(directory[directory.Length - 1]);
                    counter++;
                    SimulateSearchAbort();
                }
            }

            ProcessStatus?.Invoke(GetStatusMessage("folder", counter));
            return dirList;
        }

        private string GetStatusMessage(string type, int counter)
        {
            string message = String.Empty;

            if (counter == 0)
            {
                message = $"No {type} was found";
            }
            else
            {
                if (type.ToLower() == "file")
                {
                    message = _flag ? "Filtered File Found" : "File Found";
                }
                if (type.ToLower() == "folder")
                {
                    message = _flag ? "Filtered Folder Found" : "Folder Found";
                }
            }

            return message;
        }

        /*  public virtual IEnumerable<string> VisitFiles(string root)
          {
              ProcessStatus?.Invoke("Process Started");

              ProcessStatus?.Invoke(GetStatusMessage("file"));

              int counter = 0;

              foreach (var filePath in Directory.EnumerateFiles(root))
              {
                  if (_filter(filePath))
                  {
                      var file = filePath.Split('\\');
                      yield return file[file.Length - 1];
                      counter++;

                      SimulateSearchAbort();
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
          }*/

        /* private IEnumerable<string> VisitDirectory(string root)
         {
             ProcessStatus?.Invoke(GetStatusMessage("folder"));

             int counter = 0;

             foreach (var subDirectory in Directory.EnumerateDirectories(root))
             {
                 var directory = subDirectory.Split('\\');
                 if (_filter(directory[directory.Length - 1]))
                 {
                     yield return directory[directory.Length - 1];
                     counter++;
                     SimulateSearchAbort();
                 }
             }

             if (counter == 0)
             {
                 ProcessStatus?.Invoke("Nothing had been found");
             }
             ProcessStatus?.Invoke("Process Finished");
         }*/

        /*  private string GetStatusMessage(string type)
          {
              string message=String.Empty;

              if(type.ToLower() == "file")
              {
                  message = _flag ? "Filtered File Found" : "File Found";
              }
              if(type.ToLower() == "folder")
              {
                  message = _flag ? "Filtered Folder Found" : "Folder Found";
              }            

              return message;
          }*/

        private void SimulateSearchAbort()
        {
            var rnd = new Random();
            if (rnd.Next(0, 15) == 0)
            {
                Thread.Sleep(5000);
                ProcessStatus?.Invoke("Search aborted");
                Environment.Exit(408);
            }
            else
            {
                return;
            }
        }

        #region IfYouWantToGetAllFilesFromFolders
        private IEnumerable<string> GetAllFIles(string root)
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
