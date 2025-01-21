using Entities;

namespace Repositories
{
    public interface IProductRpository
    {
        Task<List<Product>> Get(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);

    }
}