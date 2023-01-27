using MyProduct.Domain;
using MyProduct.Domain.Contracts;
using MyProduct.Persistence.Seedwork;

namespace MyProduct.Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext myDbContext)
            : base(myDbContext)
        {

        }
    }
}
