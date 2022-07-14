using NLayer.Core.DTOS;
using NLayer.Core.Models;

namespace NLayer.Core.Services
{
    public interface IProductService : IService<Product>
    {

        Task<List<ProductWithCategoryDto>> GetProductsWithCategory();
    }
}
