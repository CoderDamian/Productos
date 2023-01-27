using MyProduct.Domain.Entities;
using MyProduct.Domain.Seedwork;

namespace MyProduct.Domain.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
