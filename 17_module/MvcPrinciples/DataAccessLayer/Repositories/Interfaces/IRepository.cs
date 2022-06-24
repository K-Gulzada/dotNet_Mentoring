namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRepository<T> where T:class
    {
        List<T> GetAll();
        T Get(int id);
        T Get(string name);
        void Create(T item);
        void Update(T item);
        bool Delete(int id);
    }
}
