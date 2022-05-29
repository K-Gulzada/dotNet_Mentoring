using File_Cabinet.Entities;

namespace File_Cabinet.Repositories.interfaces
{
    public interface IDocumentRepository
    {
        List<Document> GetAll();
        void StoreDocument(List<Document> data, string path);
        List<Document> SearchByDocumentNumber(string documentNumber);
    }
}
