using File_Cabinet.Entities;
using File_Cabinet.Repositories.interfaces;
using File_Cabinet.Serializer;

namespace File_Cabinet.Repositories.impl
{
    public class DocumentRepository : IDocumentRepository
    {
        public List<Document> GetAll()
        {
            return SeedExtension.CreateDefaultDocument();
        }
        public void StoreDocument(List<Document> documents, string path)
        {
            MyJsonSerializer<object> serializer = new MyJsonSerializer<object>(path);

            foreach (var document in documents)
            {
                Type objectType = document.GetType();
                var instance = Activator.CreateInstance(objectType);
                instance = document;
                serializer.Serialize(instance);
            }

        }
        public List<Document> SearchByDocumentNumber(string documentNumber)
        {
            var allDocuments = SeedExtension.CreateDefaultDocument();
            var filteredDocuments = allDocuments.Where(x => x.DocumentNumber == documentNumber).ToList();

            return filteredDocuments;
        }
    }
}
