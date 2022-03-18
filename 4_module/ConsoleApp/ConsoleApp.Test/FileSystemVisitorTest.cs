using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp.Test
{
    [TestFixture]
    public class FileSystemVisitorTest
    {
        private readonly FileSystemVisitor _visitor;
        private readonly FileSystemVisitor _visitorWithFilter;
        private readonly string _path = "C:\\Users\\Gulzada_Kakhar\\Desktop";
        Predicate<string> _predicate = (info) => info.Contains("xm");

        public FileSystemVisitorTest()
        {
            _visitor = new FileSystemVisitor(_path);
            _visitorWithFilter = new FileSystemVisitor(_path, _predicate);
        }

        [Test]
        public void VisitFiles_Return_AllFiles()
        {
            // Arrange
            IEnumerable<string> expectedFiles = new[] { "EPAM Toolkit.url", "Microsoft Teams.lnk", "Net Mentoring.docx",
                                                 "test.xml", "Visual Studio Code.lnk", ".Net Mentoring Program",
                                                "CitrixWorkspaceAppWeb_1912CU5", "New folder", "Projectsxm" };

            // Act
            IEnumerable<string> actualFiles = _visitor.VisitFiles(_path);

            // Assert
            Assert.AreEqual(expectedFiles, actualFiles);
        }

        [Test]
        public void VisitFiles_Return_FilteredFiles()
        {
            // Arrange
            IEnumerable<string> expectedFiles = new[] { "test.xml", "Projectsxm" };

            // Act
            IEnumerable<string> actualFiles = _visitorWithFilter.VisitFiles(_path);

            // Assert
            Assert.AreEqual(expectedFiles, actualFiles);
        }

        [Test]
        public void Path_Null_ThrowsArgumentNullException()
        {
            Assert.That(() =>
            {
                string? path = null;
                Predicate<string> predicate = (info) => info.Contains("xm");

                var productToFind = new FileSystemVisitor(path, predicate);
            }, Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Invalid_Path_ThrowsDirectoryNotFoundException()
        {
            Assert.That(() =>
            {
                string path = "C:\\Users\\Gulzada_Kakhar\\Desktop\\DoesNotExistFolder";
                Predicate<string> predicate = (info) => info.Contains("xm");

                var productToFind = new FileSystemVisitor(path, predicate);
            }, Throws.InstanceOf<DirectoryNotFoundException>());
        }

        [Test]
        public void Predicate_Null_ThrowsArgumentNullException()
        {
            Assert.That(() =>
            {
                string path = "C:\\Users\\Gulzada_Kakhar\\Desktop";
                Predicate<string> predicate = null;

                var productToFind = new FileSystemVisitor(path, predicate);
            }, Throws.InstanceOf<ArgumentNullException>());
        }

    }
}