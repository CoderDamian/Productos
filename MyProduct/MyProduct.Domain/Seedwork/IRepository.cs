namespace MyProduct.Domain.Seedwork
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIDAsync(int ID);
        void DeleteAsync(T entity);
        void Update(T entity);
    }
}
