namespace MyProduct.Domain.Seedwork
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync(int ID);
        void UpdateAsync(T entity);
    }
}
