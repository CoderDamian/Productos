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

        public async Task DeleteAsync(int ID)
        {
            T? entity = await _myDbContext.Set<T>().FindAsync(ID);

            if (entity == null)
                throw new NullReferenceException(nameof(entity));

            _myDbContext.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _myDbContext.Set<T>().ToListAsync();
        }

        public void UpdateAsync(T entity)
        {
            _myDbContext.Set<T>().Update(entity);
        }
    }
}
