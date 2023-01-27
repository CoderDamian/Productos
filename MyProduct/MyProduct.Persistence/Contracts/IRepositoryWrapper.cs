using MyProduct.Domain.Contracts;

namespace MyProduct.Persistence.Contracts
{
    public interface IRepositoryWrapper
    {
        public IProductRepository ProductRepository { get; }
        public Task SaveAsync();
    }
}
