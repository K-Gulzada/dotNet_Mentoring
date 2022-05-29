using File_Cabinet.cache;
using File_Cabinet.Entities;
using File_Cabinet.Repositories.impl;

namespace FileCabinet
{
    class Program
    {
        public static void Main(string[] args)
        {
            DocumentRepository repository = new();
            var allDocs = repository.GetAll();
            repository.StoreDocument(allDocs);

            var filteredDocs = repository.SearchByDocumentNumber("DN_111 Book");
            var books = new List<Book>();

            foreach(var doc in filteredDocs)
            {
                books.Add((Book)doc);
            }

            foreach(var book in books)
            {
                book.ToString();
            }

            repository.StoreDocument(filteredDocs);

            var cacheDocument = new CacheDocument<Book>();
          
            var myCachedDoc = cacheDocument.GetOrCreate("DN_111 Book", () => books[0]);

            Console.ReadKey();

        }
    }
}


// ключевое слово new
// композиция / агрегация  (пример relation in sql)
// rename files/folders +
// without reflection +
// use NewtonSoft
// numbers to Const +
// IEnumerable
// method transform LINQ








