using Microsoft.EntityFrameworkCore;
using MyProduct.Domain.Seedwork;

namespace MyProduct.Persistence.Seedwork
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly MyDbContext _myDbContext;

        public RepositoryBase(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _myDbContext.Set<T>().AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
            _myDbContext.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _myDbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIDAsync(int ID)
        {
            T? entity = await _myDbContext.Set<T>().FindAsync(ID).ConfigureAwait(false);

            return entity;
        }

        public void Update(T entity)
        {
            _myDbContext.Set<T>().Update(entity);
        }
    }
}
