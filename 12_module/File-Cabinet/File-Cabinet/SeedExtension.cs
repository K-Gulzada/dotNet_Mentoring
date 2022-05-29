using File_Cabinet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Cabinet
{
    public static class SeedExtension
    {
        public static List<Book> CreateDefaultBooks()
        {
            var books = new List<Book> {
                 new Book
                 {
                    DocumentNumber = "DN_111 Book",
                    Title = "Book 1",
                    ISBN = "231-345-989-1239",
                    NumberOfPages = 290,
                    Publisher = "Publisher 1",
                    Authors = new List<string> { "Author 1", "Author 2" },
                    PublishedDate = DateTime.Now
                 },
                  new Book
                 {
                    DocumentNumber = "DN_111 Book",
                    Title = "Book 2",
                    ISBN = "874-024-817-4243",
                    NumberOfPages = 300,
                    Publisher = "Publisher 2",
                    Authors = new List<string> { "Author 3", "Author 4" },
                    PublishedDate = DateTime.Now
                 }
            };

            return books;
        }

        public static List<LocalizedBook> CreateDefaultLocalizedBooks()
        {
            var localizedBooks = new List<LocalizedBook>
            {
                new LocalizedBook
                {
                    DocumentNumber = "DN_222 LocalizedBook",
                    Title = "LocalizedBook 1",
                    ISBN = "678-123-345-8374",
                    NumberOfPages = 350,
                    Publisher = "LocalizedBook Publisher",
                    OriginalPublisher = "OriginalPublisher",
                    LocalPublisher = "LocalPublisher",
                    LocalizationCountry = "Country",
                    Authors = new List<string> { "Author 1", "Author 2" },
                    PublishedDate = DateTime.Now
                },
                new LocalizedBook
                {
                    DocumentNumber = "DN_222 LocalizedBook",
                    Title = "LocalizedBook 2",
                    ISBN = "012-764-029-1293",
                    NumberOfPages = 880,
                    Publisher = "Publisher 1",
                    OriginalPublisher = "OriginalPublisher",
                    LocalPublisher = "LocalPublisher 2",
                    LocalizationCountry = "Country",
                    Authors = new List<string> { "Author 3", "Author 4" },
                    PublishedDate = DateTime.Now
                }
            };

            return localizedBooks;
        }

        public static List<Document> CreateDefaultDocument()
        {
           /* var document_1 = new Document
            {
                DocumentNumber = Guid.NewGuid().ToString(),
                Title = "Document Title",
                PublishedDate = DateTime.Now
            };*/

            var books = CreateDefaultBooks();
            var localizedBooks = CreateDefaultLocalizedBooks();

            var documents = new List<Document>();
            foreach(var book in books)
            {
                documents.Add(book);
            }
            foreach (var lb in localizedBooks)
            {
                documents.Add(lb);
            }

            return documents;

        }
    }
}
