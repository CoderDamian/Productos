using MyProduct.Domain.Contracts;
using MyProduct.Persistence.Contracts;

namespace MyProduct.Persistence.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly MyDbContext _myDbContext;
        private IProductRepository _productRepository;

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_myDbContext);

                return _productRepository;
            }
        }

        public RepositoryWrapper(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        public async Task SaveAsync()
        {
            await _myDbContext.SaveChangesAsync();
        }
    }
}
