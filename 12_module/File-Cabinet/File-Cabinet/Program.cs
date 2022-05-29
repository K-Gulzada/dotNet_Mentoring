using File_Cabinet.cache;
using File_Cabinet.Entities;
using File_Cabinet.Repositories.impl;

namespace FileCabinet
{
    class Program
    {
        public static void Main(string[] args)
        {
            DocumentRepository<Book> repo = new DocumentRepository<Book>();
            var allDocs = repo.GetAll();
            repo.StoreDocument(allDocs, $"allDocs.json");

            var books = repo.SearchByDocumentNumber("DN_111 Book");
            repo.StoreDocument(books, $"{books[0].GetType().Name}_#{allDocs[0].DocumentNumber}.json");

            foreach (var book in books)
            {
                Console.WriteLine(book.DocumentNumber + " " + book.Title + " \n" + book.ISBN + " " + book.NumberOfPages + " \n" + book.PublishedDate);
            }

            var cacheDocument = new CacheDocument<Book>();
          
            var myCachedDoc = cacheDocument.GetOrCreate("DN_111 Book", () => books[0]);

            Console.ReadKey();

        }
    }
}


// ключевое слово new
// композиция / агрегация  (пример relation in sql)
// rename files/folders
// without reflection
// use NewtonSoft
// numbers to Const 
// IEnumerable
// nethod transform LINQ








