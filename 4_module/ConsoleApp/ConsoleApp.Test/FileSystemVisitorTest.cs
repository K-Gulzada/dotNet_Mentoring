using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions.TestingHelpers;

namespace ConsoleApp.Test
{
    [TestFixture]
    public class FileSystemVisitorTest
    {
        private string _path = "C:\\";
        Predicate<string> _predicate = (info) => info.Contains("xm");

        [Test]
        public void VisitFiles_Return_AllFiles()
        {
            IEnumerable<string> actualFiles = new[] { "C:\\test.txt", "C:\\config.xml" };

            var mockFileIO = new Mock<FileSystemVisitor>(_path);
            mockFileIO.Setup(t => t.GetFilesAndFolders(It.IsAny<string>())).Returns(actualFiles);
            var myFiles = mockFileIO.Object.GetFilesAndFolders(_path);             

            Assert.IsNotNull(myFiles);
            Assert.AreEqual(myFiles, actualFiles);
        }

        [Test]
        public void Path_Null_ThrowsArgumentNullException()
        {
            Assert.That(() =>
            {
                var result = new FileSystemVisitor(null, _predicate);
            }, Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Invalid_Path_ThrowsDirectoryNotFoundException()
        {
            Assert.That(() =>
            {
                string path = "C:\\DoesNotExistFolder";

                var result = new FileSystemVisitor(path, _predicate);
            }, Throws.InstanceOf<DirectoryNotFoundException>());
        }

        [Test]
        public void Predicate_Null_ThrowsArgumentNullException()
        {
            Assert.That(() =>
            {
                var result = new FileSystemVisitor(_path, null);
            }, Throws.InstanceOf<ArgumentNullException>());
        }

    }
}