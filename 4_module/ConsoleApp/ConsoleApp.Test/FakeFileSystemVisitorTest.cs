using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions.TestingHelpers;

namespace ConsoleApp.Test
{
    [TestFixture]
    public class FakeFileSystemVisitorTest
    {
        private string _path = "C:\\";

        [Test]
        public void VisitFiles_Return_AllFiles()
        {
            IEnumerable<string> actualFiles = new[] { "test.txt", "config.xml", "temp" };

            var mockFileSystem = new MockFileSystem();
            mockFileSystem.AddFile(("test.txt"), MockFileData.NullObject);
            mockFileSystem.AddFile(("config.xml"), MockFileData.NullObject);
            var fakeFisitor = new FakeFileSystemVisitor(mockFileSystem, _path);
            var myFiles = fakeFisitor.VisitFiles(_path);

            Assert.IsNotNull(myFiles);
            Assert.AreEqual(myFiles, actualFiles);
        }



    }
}