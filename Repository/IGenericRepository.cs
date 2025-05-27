namespace MassageApi_V1.Repository
{
    public interface IGenericRepository<T>
    {
        public Task<List<T>> GetAll();
        public Task<T?> GetById(int id);
        public Task<T?> Update(T value);
        public Task<T> Add(T value);
        public Task<T?> Delete(int id);
    }
}
