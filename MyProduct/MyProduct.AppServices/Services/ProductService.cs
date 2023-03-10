using AutoMapper;
using MyProduct.AppServices.Contracts;
using MyProduct.AppServices.DTOs;
using MyProduct.Domain.Entities;
using MyProduct.Persistence.Contracts;

namespace MyProduct.AppServices.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryWrapper repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }  

        public async Task AddAsync(CreateProductDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Product productToSave = _mapper.Map<Product>(entity);

            await _repository.ProductRepository
                .AddAsync(productToSave)
                .ConfigureAwait(false);
        }

        public async Task DeleteAsync(int ID)
        {
            Product? product = await _repository.ProductRepository
                .GetByIDAsync(ID)
                .ConfigureAwait(false);

            if (product == null)
                throw new NullReferenceException(nameof(product));

            _repository.ProductRepository.DeleteAsync(product);
        }

        public async Task<IEnumerable<ListProductsDTO>> GetAllAsync()
        {
            IEnumerable<Product> products = await _repository.ProductRepository
                .GetAllAsync()
                .ConfigureAwait(false);

            IEnumerable<ListProductsDTO> productsDTO;

            productsDTO = _mapper.Map<IEnumerable<ListProductsDTO>>(products);

            return productsDTO;
        }

        public async Task<UpdateProductDTO> GetByIDAsync(int ID)
        {
            Product product = await _repository.ProductRepository.GetByIDAsync(ID).ConfigureAwait(false);

            UpdateProductDTO productDTO = new UpdateProductDTO();

            _mapper.Map(product, productDTO);

            return productDTO;
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(int ID, UpdateProductDTO entityDTO)
        {
            Product? product = await _repository.ProductRepository
                .GetByIDAsync(ID)
                .ConfigureAwait(false);

            if (product == null)
                throw new NullReferenceException(nameof(product));

            //_mapper.Map<product>(entity);
            _mapper.Map(entityDTO, product);

            _repository.ProductRepository.Update(product);
        }
    }
}
