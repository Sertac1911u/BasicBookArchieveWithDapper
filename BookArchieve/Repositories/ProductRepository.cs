using BookArchieve.Dtos;
using System.Threading.Tasks;

namespace BookArchieve.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task CreateProductAsync(CreateProductDto createProductDto)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task GetByProductIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResultProductDto> GettAllProductAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
