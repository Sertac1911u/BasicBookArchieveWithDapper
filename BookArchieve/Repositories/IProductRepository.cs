using BookArchieve.Dtos;
using System.Threading.Tasks;

namespace BookArchieve.Repositories
{
    public interface IProductRepository
    {
        Task<ResultProductDto> GettAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(int id);
        Task GetByProductIdAsync(int id);
    }
}
