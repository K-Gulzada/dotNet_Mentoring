using File_Cabinet.Entities;
using File_Cabinet.Repositories.interfaces;
using File_Cabinet.Serializer;

namespace File_Cabinet.Repositories.impl
{
    public class DocumentRepository : IDocumentRepository
    {
        public List<Document> GetAll()
        {
            var allDocuments = SeedExtension.CreateDefaultDocument();
          /*
            List<T> docs = new List<T>();

            foreach (var fd in allDocuments)
            {
                Type objectType = fd.GetType();
                T instance = (T)Activator.CreateInstance(objectType);

                docs.Add(fd as T);
            }
*/
            return allDocuments;
        }
        public void StoreDocument(List<Document> data, string path)
        {
            MyJsonSerializer<T> serializer = new MyJsonSerializer<T>(path);

            foreach (var doc in data)
            {
                serializer.Serialize(doc);
            }
        }
        public List<T> SearchByDocumentNumber(string documentNumber)
        {
            var allDocuments = SeedExtension.CreateDefaultDocument();
            var filteredDocuments = allDocuments.Where(x => x.DocumentNumber == documentNumber).ToList();

            List<T> identifiedDocs = new List<T>();

            foreach (var fd in filteredDocuments)
            {
                Type objectType = fd.GetType();
                T instance = (T)Activator.CreateInstance(objectType);

                identifiedDocs.Add(fd as T);
            }

            return identifiedDocs;
        }
    }
}
