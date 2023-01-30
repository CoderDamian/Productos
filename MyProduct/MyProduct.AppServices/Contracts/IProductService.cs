using MyProduct.AppServices.DTOs;

namespace MyProduct.AppServices.Contracts
{
    public interface IProductService
    {
        Task AddAsync(CreateProductDTO entityDTO);
        Task<IEnumerable<ListProductsDTO>> GetAllAsync();
        Task<UpdateProductDTO> GetByIDAsync(int ID);

        Task DeleteAsync(int ID);
        Task UpdateAsync(int ID, UpdateProductDTO entityDTO);
        Task SaveAsync();
    }
}
