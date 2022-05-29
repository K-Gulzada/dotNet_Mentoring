using File_Cabinet.Entities;
using File_Cabinet.Repositories.interfaces;
using Newtonsoft.Json;

namespace File_Cabinet.Repositories.impl
{
    public class DocumentRepository : IDocumentRepository
    {
        public List<Document> GetAll()
        {
            return SeedExtension.CreateDefaultDocument();
        }
        public void StoreDocument(List<Document> documents)
        {
            foreach (var document in documents)
            {
                Type objectType = document.GetType();
                var instance = Activator.CreateInstance(objectType);
                instance = document;
   
                File.WriteAllText($"{document.DocumentNumber}.json", JsonConvert.SerializeObject(instance));
            }
        }
        public List<Document> SearchByDocumentNumber(string documentNumber)
        {
            var allDocuments = SeedExtension.CreateDefaultDocument();

            return allDocuments.Where(x => x.DocumentNumber == documentNumber).ToList();
        }
    }
}
